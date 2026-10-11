namespace Bai_1
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
            txtMaTL = new TextBox();
            lblTen = new Label();
            txtTenTheLoai = new TextBox();
            lblMoTa = new Label();
            txtMoTa = new TextBox();
            lblSoLuong = new Label();
            nudSoLuongSach = new NumericUpDown();
            lblNgayTaoTitle = new Label();
            lblNgayTao = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            dgvTheLoai = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongSach).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
            SuspendLayout();

            // lblMa
            lblMa.AutoSize = true;
            lblMa.Location = new Point(20, 25);
            lblMa.Name = "lblMa";
            lblMa.Text = "Mã thể loại";

            // txtMaTL
            txtMaTL.Location = new Point(130, 22);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.ReadOnly = true;
            txtMaTL.Size = new Size(200, 27);

            // lblTen
            lblTen.AutoSize = true;
            lblTen.Location = new Point(20, 65);
            lblTen.Name = "lblTen";
            lblTen.Text = "Tên thể loại";

            // txtTenTheLoai
            txtTenTheLoai.Location = new Point(130, 62);
            txtTenTheLoai.MaxLength = 100;
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new Size(200, 27);

            // lblMoTa
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(20, 105);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Text = "Mô tả";

            // txtMoTa
            txtMoTa.Location = new Point(130, 102);
            txtMoTa.MaxLength = 255;
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(200, 80);

            // lblSoLuong
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(20, 200);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Text = "Số lượng sách";

            // nudSoLuongSach
            nudSoLuongSach.Location = new Point(130, 197);
            nudSoLuongSach.Maximum = 1000000;
            nudSoLuongSach.Minimum = 0;
            nudSoLuongSach.Name = "nudSoLuongSach";
            nudSoLuongSach.Size = new Size(200, 27);
            nudSoLuongSach.Value = 0;

            // lblNgayTaoTitle
            lblNgayTaoTitle.AutoSize = true;
            lblNgayTaoTitle.Location = new Point(20, 240);
            lblNgayTaoTitle.Name = "lblNgayTaoTitle";
            lblNgayTaoTitle.Text = "Ngày tạo:";

            // lblNgayTao
            lblNgayTao.AutoSize = true;
            lblNgayTao.Location = new Point(130, 240);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Text = "";

            // btnThem
            btnThem.Location = new Point(380, 22);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(110, 35);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;

            // btnSua
            btnSua.Location = new Point(380, 70);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(110, 35);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;

            // btnXoa
            btnXoa.Location = new Point(380, 118);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(110, 35);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;

            // btnLamMoi
            btnLamMoi.Location = new Point(380, 166);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(110, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;

            // lblTimKiem
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(20, 285);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Text = "Tìm theo tên";

            // txtTimKiem
            txtTimKiem.Location = new Point(130, 282);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(360, 27);
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            // dgvTheLoai
            dgvTheLoai.AllowUserToAddRows = false;
            dgvTheLoai.AllowUserToDeleteRows = false;
            dgvTheLoai.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTheLoai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheLoai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheLoai.Location = new Point(20, 320);
            dgvTheLoai.MultiSelect = false;
            dgvTheLoai.Name = "dgvTheLoai";
            dgvTheLoai.ReadOnly = true;
            dgvTheLoai.RowHeadersVisible = false;
            dgvTheLoai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTheLoai.Size = new Size(750, 210);
            dgvTheLoai.SelectionChanged += dgvTheLoai_SelectionChanged;

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(790, 550);
            Controls.Add(lblMa);
            Controls.Add(txtMaTL);
            Controls.Add(lblTen);
            Controls.Add(txtTenTheLoai);
            Controls.Add(lblMoTa);
            Controls.Add(txtMoTa);
            Controls.Add(lblSoLuong);
            Controls.Add(nudSoLuongSach);
            Controls.Add(lblNgayTaoTitle);
            Controls.Add(lblNgayTao);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(lblTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(dgvTheLoai);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý thể loại sách - Tri Thức Books";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nudSoLuongSach).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblMa;
        private TextBox txtMaTL;
        private Label lblTen;
        private TextBox txtTenTheLoai;
        private Label lblMoTa;
        private TextBox txtMoTa;
        private Label lblSoLuong;
        private NumericUpDown nudSoLuongSach;
        private Label lblNgayTaoTitle;
        private Label lblNgayTao;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private DataGridView dgvTheLoai;
    }
}