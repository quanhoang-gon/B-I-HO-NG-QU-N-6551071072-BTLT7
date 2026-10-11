namespace Bai_2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMa = new Label();
            txtMaHV = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblGioiTinh = new Label();
            grpGioiTinh = new GroupBox();
            radNam = new RadioButton();
            radNu = new RadioButton();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblSDT = new Label();
            txtSDT = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblHang = new Label();
            cboHang = new ComboBox();
            chkTrangThai = new CheckBox();
            lblNgayDKTitle = new Label();
            lblNgayDangKy = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimTen = new Label();
            txtTimKiem = new TextBox();
            lblLocHang = new Label();
            cboLocHang = new ComboBox();
            dgvHoiVien = new DataGridView();
            grpGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).BeginInit();
            SuspendLayout();

            // lblMa
            lblMa.AutoSize = true;
            lblMa.Location = new Point(20, 25);
            lblMa.Name = "lblMa";
            lblMa.Text = "Mã hội viên";

            // txtMaHV
            txtMaHV.Location = new Point(140, 22);
            txtMaHV.Name = "txtMaHV";
            txtMaHV.ReadOnly = true;
            txtMaHV.Size = new Size(220, 27);

            // lblHoTen
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(20, 65);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Text = "Họ tên";

            // txtHoTen
            txtHoTen.Location = new Point(140, 62);
            txtHoTen.MaxLength = 100;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(220, 27);

            // lblGioiTinh
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(20, 112);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Text = "Giới tính";

            // grpGioiTinh
            grpGioiTinh.Controls.Add(radNam);
            grpGioiTinh.Controls.Add(radNu);
            grpGioiTinh.Location = new Point(140, 95);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new Size(220, 52);
            grpGioiTinh.TabStop = false;
            grpGioiTinh.Text = "Giới tính";

            // radNam
            radNam.AutoSize = true;
            radNam.Checked = true;
            radNam.Location = new Point(15, 22);
            radNam.Name = "radNam";
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;

            // radNu
            radNu.AutoSize = true;
            radNu.Location = new Point(110, 22);
            radNu.Name = "radNu";
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;

            // lblNgaySinh
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(20, 170);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Text = "Ngày sinh";

            // dtpNgaySinh
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(140, 165);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(220, 27);
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);

            // lblSDT
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(20, 210);
            lblSDT.Name = "lblSDT";
            lblSDT.Text = "Số điện thoại";

            // txtSDT
            txtSDT.Location = new Point(140, 207);
            txtSDT.MaxLength = 15;
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(220, 27);

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 250);
            lblEmail.Name = "lblEmail";
            lblEmail.Text = "Email";

            // txtEmail
            txtEmail.Location = new Point(140, 247);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 27);

            // lblHang
            lblHang.AutoSize = true;
            lblHang.Location = new Point(400, 25);
            lblHang.Name = "lblHang";
            lblHang.Text = "Hạng thành viên";

            // cboHang
            cboHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHang.Items.AddRange(new object[] { "Basic", "VIP", "Premium" });
            cboHang.Location = new Point(530, 22);
            cboHang.Name = "cboHang";
            cboHang.Size = new Size(160, 28);
            cboHang.SelectedIndex = 0;

            // chkTrangThai
            chkTrangThai.AutoSize = true;
            chkTrangThai.Checked = true;
            chkTrangThai.CheckState = CheckState.Checked;
            chkTrangThai.Location = new Point(530, 66);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Text = "Đang hoạt động";
            chkTrangThai.UseVisualStyleBackColor = true;

            // lblNgayDKTitle
            lblNgayDKTitle.AutoSize = true;
            lblNgayDKTitle.Location = new Point(400, 110);
            lblNgayDKTitle.Name = "lblNgayDKTitle";
            lblNgayDKTitle.Text = "Ngày đăng ký:";

            // lblNgayDangKy
            lblNgayDangKy.AutoSize = true;
            lblNgayDangKy.Location = new Point(530, 110);
            lblNgayDangKy.Name = "lblNgayDangKy";
            lblNgayDangKy.Text = "";

            // btnThem
            btnThem.Location = new Point(730, 22);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(140, 35);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;

            // btnSua
            btnSua.Location = new Point(730, 70);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(140, 35);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;

            // btnXoa
            btnXoa.Location = new Point(730, 118);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(140, 35);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;

            // btnLamMoi
            btnLamMoi.Location = new Point(730, 166);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(140, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;

            // lblTimTen
            lblTimTen.AutoSize = true;
            lblTimTen.Location = new Point(20, 295);
            lblTimTen.Name = "lblTimTen";
            lblTimTen.Text = "Tìm theo họ tên";

            // txtTimKiem
            txtTimKiem.Location = new Point(140, 292);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(220, 27);
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            // lblLocHang
            lblLocHang.AutoSize = true;
            lblLocHang.Location = new Point(400, 295);
            lblLocHang.Name = "lblLocHang";
            lblLocHang.Text = "Lọc theo hạng";

            // cboLocHang
            cboLocHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocHang.Items.AddRange(new object[] { "Tất cả", "Basic", "VIP", "Premium" });
            cboLocHang.Location = new Point(530, 292);
            cboLocHang.Name = "cboLocHang";
            cboLocHang.Size = new Size(160, 28);
            cboLocHang.SelectedIndex = 0;
            cboLocHang.SelectedIndexChanged += cboLocHang_SelectedIndexChanged;

            // dgvHoiVien
            dgvHoiVien.AllowUserToAddRows = false;
            dgvHoiVien.AllowUserToDeleteRows = false;
            dgvHoiVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHoiVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoiVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoiVien.Location = new Point(20, 335);
            dgvHoiVien.MultiSelect = false;
            dgvHoiVien.Name = "dgvHoiVien";
            dgvHoiVien.ReadOnly = true;
            dgvHoiVien.RowHeadersVisible = false;
            dgvHoiVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoiVien.Size = new Size(860, 285);
            dgvHoiVien.CellFormatting += dgvHoiVien_CellFormatting;
            dgvHoiVien.SelectionChanged += dgvHoiVien_SelectionChanged;

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 640);
            Controls.Add(lblMa);
            Controls.Add(txtMaHV);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblGioiTinh);
            Controls.Add(grpGioiTinh);
            Controls.Add(lblNgaySinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblSDT);
            Controls.Add(txtSDT);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblHang);
            Controls.Add(cboHang);
            Controls.Add(chkTrangThai);
            Controls.Add(lblNgayDKTitle);
            Controls.Add(lblNgayDangKy);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(lblTimTen);
            Controls.Add(txtTimKiem);
            Controls.Add(lblLocHang);
            Controls.Add(cboLocHang);
            Controls.Add(dgvHoiVien);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý hội viên - FitZone";
            Load += Form1_Load;
            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblMa;
        private TextBox txtMaHV;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblGioiTinh;
        private GroupBox grpGioiTinh;
        private RadioButton radNam;
        private RadioButton radNu;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblSDT;
        private TextBox txtSDT;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblHang;
        private ComboBox cboHang;
        private CheckBox chkTrangThai;
        private Label lblNgayDKTitle;
        private Label lblNgayDangKy;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimTen;
        private TextBox txtTimKiem;
        private Label lblLocHang;
        private ComboBox cboLocHang;
        private DataGridView dgvHoiVien;
    }
}