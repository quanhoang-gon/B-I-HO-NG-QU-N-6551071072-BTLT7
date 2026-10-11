using Bai_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai_1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    // ============ LOAD ============
    private async void Form1_Load(object sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync(string? keyword = null)
    {
        using var db = new TriThucBooksContext();

        var query = db.TheLoaiSach.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            string kw = keyword.Trim();
            query = query.Where(t => t.TenTheLoai.Contains(kw));   // lọc trên SQL
        }

        dgvTheLoai.DataSource = await query.OrderBy(t => t.MaTl).ToListAsync();

        dgvTheLoai.Columns["MaTl"]!.HeaderText = "Mã TL";
        dgvTheLoai.Columns["TenTheLoai"]!.HeaderText = "Tên thể loại";
        dgvTheLoai.Columns["MoTa"]!.HeaderText = "Mô tả";
        dgvTheLoai.Columns["SoLuongSach"]!.HeaderText = "Số lượng sách";
        dgvTheLoai.Columns["NgayTao"]!.HeaderText = "Ngày tạo";
        dgvTheLoai.Columns["NgayTao"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
    }

    // ============ SELECTIONCHANGED ============
    private void dgvTheLoai_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvTheLoai.CurrentRow?.DataBoundItem is TheLoaiSach tl)
        {
            txtMaTL.Text = tl.MaTl.ToString();
            txtTenTheLoai.Text = tl.TenTheLoai;
            txtMoTa.Text = tl.MoTa;
            nudSoLuongSach.Value = tl.SoLuongSach;
            lblNgayTao.Text = tl.NgayTao.ToString("dd/MM/yyyy HH:mm");
        }
        else
        {
            XoaTrang();
        }
    }

    // ============ THÊM ============
    private async void btnThem_Click(object sender, EventArgs e)
    {
        string ten = txtTenTheLoai.Text.Trim();

        if (string.IsNullOrWhiteSpace(ten))
        {
            MessageBox.Show("Vui lòng nhập tên thể loại!", "Thiếu dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenTheLoai.Focus();
            return;
        }

        using var db = new TriThucBooksContext();

        if (await db.TheLoaiSach.AnyAsync(t => t.TenTheLoai == ten))
        {
            MessageBox.Show($"Thể loại \"{ten}\" đã tồn tại!", "Trùng tên",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenTheLoai.Focus();
            return;
        }

        var tl = new TheLoaiSach
        {
            TenTheLoai = ten,
            MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim(),
            SoLuongSach = (int)nudSoLuongSach.Value
        };

        db.Add(tl);
        await db.SaveChangesAsync();

        MessageBox.Show("Thêm thể loại thành công!", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        await LoadDataAsync(txtTimKiem.Text);
        BoChonVaXoaTrang();
    }

    // ============ SỬA ============
    private async void btnSua_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtMaTL.Text, out int ma))
        {
            MessageBox.Show("Hãy chọn một thể loại trong danh sách để sửa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string ten = txtTenTheLoai.Text.Trim();
        if (string.IsNullOrWhiteSpace(ten))
        {
            MessageBox.Show("Vui lòng nhập tên thể loại!", "Thiếu dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var db = new TriThucBooksContext();

        var tl = await db.TheLoaiSach.FindAsync(ma);
        if (tl == null)
        {
            MessageBox.Show("Thể loại không còn tồn tại!", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            await LoadDataAsync(txtTimKiem.Text);
            return;
        }

        if (await db.TheLoaiSach.AnyAsync(t => t.TenTheLoai == ten && t.MaTl != ma))
        {
            MessageBox.Show($"Tên \"{ten}\" đã được thể loại khác sử dụng!", "Trùng tên",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        tl.TenTheLoai = ten;
        tl.MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim();
        tl.SoLuongSach = (int)nudSoLuongSach.Value;

        await db.SaveChangesAsync();

        MessageBox.Show("Cập nhật thành công!", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        await LoadDataAsync(txtTimKiem.Text);
    }

    // ============ XÓA ============
    private async void btnXoa_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtMaTL.Text, out int ma))
        {
            MessageBox.Show("Hãy chọn một thể loại trong danh sách để xóa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var xacNhan = MessageBox.Show(
            $"Bạn có chắc muốn xóa thể loại \"{txtTenTheLoai.Text}\"?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (xacNhan != DialogResult.Yes) return;

        try
        {
            using var db = new TriThucBooksContext();

            var tl = await db.TheLoaiSach.FindAsync(ma);
            if (tl != null)
            {
                db.Remove(tl);
                await db.SaveChangesAsync();
            }

            MessageBox.Show("Xóa thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadDataAsync(txtTimKiem.Text);
            BoChonVaXoaTrang();
        }
        catch (DbUpdateException)
        {
            MessageBox.Show(
                "Không thể xóa vì thể loại này đang được sách khác tham chiếu!",
                "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ============ TÌM KIẾM ============
    private async void txtTimKiem_TextChanged(object sender, EventArgs e)
    {
        await LoadDataAsync(txtTimKiem.Text);
    }

    // ============ LÀM MỚI ============
    private async void btnLamMoi_Click(object sender, EventArgs e)
    {
        txtTimKiem.TextChanged -= txtTimKiem_TextChanged;
        txtTimKiem.Clear();
        txtTimKiem.TextChanged += txtTimKiem_TextChanged;

        await LoadDataAsync();
        BoChonVaXoaTrang();
    }

    // ============ HÀM PHỤ ============
    private void XoaTrang()
    {
        txtMaTL.Clear();
        txtTenTheLoai.Clear();
        txtMoTa.Clear();
        nudSoLuongSach.Value = 0;
        lblNgayTao.Text = "";
    }

    private void BoChonVaXoaTrang()
    {
        dgvTheLoai.CurrentCell = null;
        XoaTrang();
        txtTenTheLoai.Focus();
    }
}