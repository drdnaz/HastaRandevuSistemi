using System.Data.SqlClient;
using HastaRandevuSistemi.Models;

using HastaRandevuSistemi.Models;
using HastaRandevuSistemi.Models.KayitFormu1.Models;



namespace HastaRandevuSistemi
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=NAZ;Initial Catalog=AcunMedya_CMT19;Integrated Security=SSPI;";

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            BranslariGetir();
            SaatleriGetir();
        }
        private void BranslariGetir()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT Id, BransAdi FROM Branslar";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    var bransList = new List<Brans>();
                    bransList.Add(new Brans { Id = -1, BransAdi = "Branş Seçiniz" });

                    while (reader.Read())
                    {
                        bransList.Add(new Brans
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            BransAdi = reader["BransAdi"].ToString()
                        });
                    }

                    cmbBrans.DataSource = bransList;
                    cmbBrans.DisplayMember = "BransAdi";
                    cmbBrans.ValueMember = "Id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBrans.SelectedItem is Brans secilenBrans && secilenBrans.Id > 0)
            {
                DoktorlariGetir(secilenBrans.Id);
            }
            else
            {
                cmbDoktor.DataSource = null;
            }
        }

        private void DoktorlariGetir(int bransId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Doktor> doktorListesi = new List<Doktor>();
                doktorListesi.Add(new Doktor { Id = -1, DoktorAdi = "Doktor Seçiniz", DoktorSoyadi = "" });
                try
                {
                    connection.Open();
                    string sorgu = "SELECT * FROM Doktorlar WHERE BransID = @BransID";
                    SqlCommand cmd = new SqlCommand(sorgu, connection);
                    cmd.Parameters.AddWithValue("@BransID", bransId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        doktorListesi.Add(new Doktor
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            DoktorAdi = reader["DoktorAdi"].ToString(),
                            DoktorSoyadi = reader["DoktorSoyadi"].ToString(),
                            BransID = Convert.ToInt32(reader["BransID"])
                        });
                    }
                    cmbDoktor.DataSource = doktorListesi;
                    cmbDoktor.DisplayMember = "DoktorAdiSoyadi";
                    cmbDoktor.ValueMember = "Id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SaatleriGetir()
        {
            List<string> saatler = new List<string>
    {
        "09:00",
        "10:00",
        "11:00",
        "13:00",
        "14:00",
        "15:00",
        "16:00"
    };

            cmbSaat.DataSource = saatler;
        }

        private void btnRandevuOlustur_Click(object sender, EventArgs e)
        {

            if (cmbBrans.SelectedIndex <= 0 || cmbDoktor.SelectedIndex <= 0 || cmbSaat.SelectedIndex < 0
                || string.IsNullOrWhiteSpace(txtHastaAdi.Text) || string.IsNullOrWhiteSpace(txtHastaSoyadi.Text))
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz!");
                return;
            }

            int bransId = (int)cmbBrans.SelectedValue;
            int doktorId = (int)cmbDoktor.SelectedValue;
            DateTime tarih = dtpTarih.Value.Date;  // sadece tarih kısmı
            string saat = cmbSaat.SelectedItem.ToString();

            // Öncelikle aynı doktor, aynı tarih ve saatte randevu var mı kontrol et
            if (RandevuVarMi(doktorId, tarih, saat))
            {
                MessageBox.Show("Seçilen doktor için bu tarih ve saatte başka bir randevu bulunmaktadır!");
                return;
            }

            // Randevu kaydet
            RandevuKaydet(txtHastaAdi.Text.Trim(), txtHastaSoyadi.Text.Trim(), bransId, doktorId, tarih, saat);

            MessageBox.Show("Randevu başarıyla oluşturuldu!");
            
        }
        private void RandevuKaydet(string hastaAdi, string hastaSoyadi, int bransId, int doktorId, DateTime tarih, string saat)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Randevular (HastaAdi, HastaSoyadi, BransID, DoktorID, Tarih, Saat) VALUES (@HastaAdi, @HastaSoyadi, @BransID, @DoktorID, @Tarih, @Saat)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@HastaAdi", hastaAdi);
                cmd.Parameters.AddWithValue("@HastaSoyadi", hastaSoyadi);
                cmd.Parameters.AddWithValue("@BransID", bransId);
                cmd.Parameters.AddWithValue("@DoktorID", doktorId);
                cmd.Parameters.AddWithValue("@Tarih", tarih);
                cmd.Parameters.AddWithValue("@Saat", saat);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private bool RandevuVarMi(int doktorId, DateTime tarih, string saat)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT COUNT(*) FROM Randevular WHERE DoktorID = @DoktorID AND CAST(Tarih AS DATE) = @Tarih AND Saat = @Saat";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DoktorID", doktorId);
                cmd.Parameters.AddWithValue("@Tarih", tarih);
                cmd.Parameters.AddWithValue("@Saat", saat);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
