namespace DatTiec.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model12")
        {
        }

        public virtual DbSet<CTDatTiec> CTDatTiecs { get; set; }
        public virtual DbSet<CTDichvu> CTDichvus { get; set; }
        public virtual DbSet<CTMenu> CTMenus { get; set; }
        public virtual DbSet<DatMon> DatMons { get; set; }
        public virtual DbSet<DatTiec> DatTiecs { get; set; }
        public virtual DbSet<Dichvu> Dichvus { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<loaiDichVu> loaiDichVus { get; set; }
        public virtual DbSet<LoaiMon> LoaiMons { get; set; }
        public virtual DbSet<Menusan> Menusans { get; set; }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<QuangCao> QuangCaos { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public virtual DbSet<TuVan> TuVans { get; set; }
        public virtual DbSet<DatSanh> DatSanhs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTDatTiec>()
                .Property(e => e.idct)
                .IsUnicode(false);

            modelBuilder.Entity<CTDatTiec>()
                .Property(e => e.iddattiec)
                .IsUnicode(false);

            modelBuilder.Entity<CTDatTiec>()
                .Property(e => e.idmonan)
                .IsUnicode(false);

            modelBuilder.Entity<CTDatTiec>()
                .Property(e => e.iddichvu)
                .IsUnicode(false);

            modelBuilder.Entity<CTDatTiec>()
                .Property(e => e.Gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CTDichvu>()
                .Property(e => e.idChiTiet)
                .IsUnicode(false);

            modelBuilder.Entity<CTDichvu>()
                .Property(e => e.iddichvu)
                .IsUnicode(false);

            modelBuilder.Entity<CTMenu>()
                .Property(e => e.idmonan)
                .IsUnicode(false);

            modelBuilder.Entity<DatMon>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<DatMon>()
                .Property(e => e.IdMon)
                .IsUnicode(false);

            modelBuilder.Entity<DatTiec>()
                .Property(e => e.iddattiec)
                .IsUnicode(false);

            modelBuilder.Entity<DatTiec>()
                .Property(e => e.Tongsotien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DatTiec>()
                .Property(e => e.Masomenu)
                .IsUnicode(false);

            modelBuilder.Entity<DatTiec>()
                .Property(e => e.Giamenu)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DatTiec>()
                .Property(e => e.Tendangnhap)
                .IsUnicode(false);

            modelBuilder.Entity<DatTiec>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<Dichvu>()
                .Property(e => e.iddichvu)
                .IsUnicode(false);

            modelBuilder.Entity<Dichvu>()
                .Property(e => e.idloai)
                .IsUnicode(false);

            modelBuilder.Entity<Dichvu>()
                .Property(e => e.Gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Tendangnhap)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<loaiDichVu>()
                .Property(e => e.idloai)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiMon>()
                .Property(e => e.idloaimon)
                .IsUnicode(false);

            modelBuilder.Entity<Menusan>()
                .Property(e => e.Gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MonAn>()
                .Property(e => e.idmonan)
                .IsUnicode(false);

            modelBuilder.Entity<MonAn>()
                .Property(e => e.idloaimon)
                .IsUnicode(false);

            modelBuilder.Entity<MonAn>()
                .Property(e => e.Gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Tendn)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<QuangCao>()
                .Property(e => e.idqc)
                .IsUnicode(false);

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.idtin)
                .IsUnicode(false);

            modelBuilder.Entity<TuVan>()
                .Property(e => e.IdTuVan)
                .IsUnicode(false);

            modelBuilder.Entity<DatSanh>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<DatSanh>()
                .Property(e => e.IdDichVu)
                .IsUnicode(false);
        }
    }
}
