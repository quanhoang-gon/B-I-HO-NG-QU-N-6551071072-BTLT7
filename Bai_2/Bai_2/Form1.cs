using Bai_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai_2;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        dtpNgaySinh.MaxDate = DateTime.Today;
        SetupGrid();
    }

    private void SetupGrid()
    {
        dgvHoiVien.AutoGenerateColumns = false;
        dgvHoiVien.Columns.Clear();

        AddCol("MaHv", "Mã HV");
        AddCol("HoTen", "Họ tên");
        AddCol("GioiTinh", "Giới tính");
        AddCol("NgaySinh", "Ngày sinh");
        AddCol("Sdt", "SĐT");
        AddCol("Email", "Email");
        AddCol("HangThanhVien", "Hạng");
        AddCol("NgayDangKy", "Ngày đăng ký");
        AddCol("TrangThai", "Trạng thái");

        dgvHoiVien.Columns["NgayDangKy"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
    }

    private void AddCol(string prop, string header)
    {
        dgvHoiVien.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = prop,
            DataPropertyName = prop,
            HeaderText = header
        });
    }

    private void dgvHoiVien_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.Value == null) return;

        switch (dgvHoiVien.Columns[e.ColumnIndex].Name)
        {
            case "GioiTinh":
                e.Value = (bool)e.Value ? "Nam" : "Nữ";
                e.FormattingApplied = true;
                break;
            case "TrangThai":
                e.Value = (bool)e.Value ? "Đang hoạt động" : "Tạm ngưng";
                e.FormattingApplied = true;
                break;
            case "NgaySinh":
                if (e.Value is DateOnly d)
                {
                    e.Value = d.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
                else if (e.Value is DateTime dt)
                {
                    e.Value = dt.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
                break;
        }
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        string ten = txtTimKiem.Text.Trim();
        string hang = cboLocHang.SelectedItem?.ToString() ?? "Tất cả";

        bool locTen = ten.Length > 0;
        bool locHang = hang != "Tất cả";

        using var db = new FitZoneContext();

        var ds = await db.HoiVien
            .AsNoTracking()
            .Where(h => (!locTen || h.HoTen.Contains(ten))
                     && (!locHang || h.HangThanhVien == hang))
            .OrderBy(h => h.MaHv)
            .ToListAsync();

        dgvHoiVien.DataSource = ds;
    }

    private async void txtTimKiem_TextChanged(object sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private async void cboLocHang_SelectedIndexChanged(object sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private void dgvHoiVien_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvHoiVien.CurrentRow?.DataBoundItem is HoiVien hv)
        {
            txtMaHV.Text = hv.MaHv.ToString();
            txtHoTen.Text = hv.HoTen;

            radNam.Checked = hv.GioiTinh;
            radNu.Checked = !hv.GioiTinh;

            DateTime ns = hv.NgaySinh.ToDateTime(TimeOnly.MinValue);
            dtpNgaySinh.Value = ns > dtpNgaySinh.MaxDate ? dtpNgaySinh.MaxDate : ns;

            txtSDT.Text = hv.Sdt;
            txtEmail.Text = hv.Email;
            cboHang.SelectedIndex = cboHang.FindStringExact(hv.HangThanhVien);
            chkTrangThai.Checked = hv.TrangThai;
            lblNgayDangKy.Text = hv.NgayDangKy.ToString("dd/MM/yyyy HH:mm");
        }
        else
        {
            XoaTrang();
        }
    }

    private bool KiemTraHopLe()
    {
        string ten = txtHoTen.Text.Trim();
        string sdt = txtSDT.Text.Trim();
        string email = txtEmail.Text.Trim();

        if (ten.Length == 0)
        {
            Loi("Vui lòng nhập họ tên!", txtHoTen);
            return false;
        }

        if (sdt.Length == 0)
        {
            Loi("Vui lòng nhập số điện thoại!", txtSDT);
            return false;
        }
        if (!sdt.All(c => c >= '0' && c <= '9'))
        {
            Loi("Số điện thoại chỉ được chứa chữ số (0-9)!", txtSDT);
            return false;
        }
        if (sdt.Length < 9 || sdt.Length > 11)
        {
            Loi($"Số điện thoại phải có từ 9 đến 11 chữ số (hiện có {sdt.Length})!", txtSDT);
            return false;
        }

        if (email.Length == 0)
        {
            Loi("Vui lòng nhập email!", txtEmail);
            return false;
        }
        if (!email.Contains('@'))
        {
            Loi("Email không hợp lệ: thiếu ký tự '@'!", txtEmail);
            return false;
        }

        int tuoi = TinhTuoi(dtpNgaySinh.Value.Date);
        if (tuoi < 15)
        {
            Loi($"Hội viên phải từ 15 tuổi trở lên (hiện {tuoi} tuổi)!", dtpNgaySinh);
            return false;
        }

        if (cboHang.SelectedIndex < 0)
        {
            Loi("Vui lòng chọn hạng thành viên!", cboHang);
            return false;
        }

        return true;
    }

    private void Loi(string thongBao, Control control)
    {
        MessageBox.Show(thongBao, "Dữ liệu không hợp lệ",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        control.Focus();
    }

    private static int TinhTuoi(DateTime ngaySinh)
    {
        DateTime homNay = DateTime.Today;
        int tuoi = homNay.Year - ngaySinh.Year;
        if (ngaySinh.Date > homNay.AddYears(-tuoi)) tuoi--;
        return tuoi;
    }

    private async void btnThem_Click(object sender, EventArgs e)
    {
        if (!KiemTraHopLe()) return;

        using var db = new FitZoneContext();

        var hv = new HoiVien
        {
            HoTen = txtHoTen.Text.Trim(),
            GioiTinh = radNam.Checked,
            NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
            Sdt = txtSDT.Text.Trim(),
            Email = txtEmail.Text.Trim(),
            HangThanhVien = cboHang.SelectedItem!.ToString()!,
            TrangThai = chkTrangThai.Checked
        };

        db.Add(hv);
        await db.SaveChangesAsync();

        MessageBox.Show($"Đã thêm hội viên \"{hv.HoTen}\" (Mã {hv.MaHv}) thành công!", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        await LoadDataAsync();
        BoChonVaXoaTrang();
    }

    private async void btnSua_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtMaHV.Text, out int ma))
        {
            MessageBox.Show("Hãy chọn một hội viên trong danh sách để sửa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!KiemTraHopLe()) return;

        using var db = new FitZoneContext();

        var hv = await db.HoiVien.FindAsync(ma);
        if (hv == null)
        {
            MessageBox.Show("Hội viên không còn tồn tại!", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            await LoadDataAsync();
            return;
        }

        hv.HoTen = txtHoTen.Text.Trim();
        hv.GioiTinh = radNam.Checked;
        hv.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
        hv.Sdt = txtSDT.Text.Trim();
        hv.Email = txtEmail.Text.Trim();
        hv.HangThanhVien = cboHang.SelectedItem!.ToString()!;
        hv.TrangThai = chkTrangThai.Checked;

        await db.SaveChangesAsync();

        MessageBox.Show("Cập nhật hội viên thành công!", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        await LoadDataAsync();
    }

    private async void btnXoa_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtMaHV.Text, out int ma))
        {
            MessageBox.Show("Hãy chọn một hội viên trong danh sách để xóa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var xacNhan = MessageBox.Show(
            $"Bạn có chắc muốn xóa hội viên \"{txtHoTen.Text}\"?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (xacNhan != DialogResult.Yes) return;

        try
        {
            using var db = new FitZoneContext();

            var hv = await db.HoiVien.FindAsync(ma);
            if (hv == null)
            {
                MessageBox.Show("Hội viên không còn tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                await LoadDataAsync();
                return;
            }

            db.Remove(hv);
            int soDong = await db.SaveChangesAsync();

            MessageBox.Show(soDong > 0 ? "Xóa hội viên thành công!" : "Không có dòng nào bị xóa!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadDataAsync();
            BoChonVaXoaTrang();
        }
        catch (DbUpdateException)
        {
            MessageBox.Show("Không thể xóa hội viên này do còn dữ liệu liên quan!",
                "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnLamMoi_Click(object sender, EventArgs e)
    {
        txtTimKiem.TextChanged -= txtTimKiem_TextChanged;
        cboLocHang.SelectedIndexChanged -= cboLocHang_SelectedIndexChanged;

        txtTimKiem.Clear();
        cboLocHang.SelectedIndex = 0;

        txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        cboLocHang.SelectedIndexChanged += cboLocHang_SelectedIndexChanged;

        await LoadDataAsync();
        BoChonVaXoaTrang();
    }

    private void XoaTrang()
    {
        txtMaHV.Clear();
        txtHoTen.Clear();
        radNam.Checked = true;
        dtpNgaySinh.Value = new DateTime(2000, 1, 1);
        txtSDT.Clear();
        txtEmail.Clear();
        cboHang.SelectedIndex = 0;
        chkTrangThai.Checked = true;
        lblNgayDangKy.Text = "";
    }

    private void BoChonVaXoaTrang()
    {
        dgvHoiVien.CurrentCell = null;
        XoaTrang();
        txtHoTen.Focus();
    }
}