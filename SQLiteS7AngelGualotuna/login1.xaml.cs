using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SQLiteS7AngelGualotuna.Models;
using System.IO;

namespace SQLiteS7AngelGualotuna
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login1 : ContentPage
    {
        private SQLiteAsyncConnection con;

        public login1()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasenia)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario = ? and Contrasenia = ?", usuario, contrasenia);
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(documentPath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasenia.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario no existe, por favor Registrarse", "OK");
                }
            }
            catch(Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "OK");

            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());

        }
    }
}