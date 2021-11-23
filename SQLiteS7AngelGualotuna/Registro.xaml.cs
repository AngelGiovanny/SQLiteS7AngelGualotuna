using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SQLiteS7AngelGualotuna.Models;

namespace SQLiteS7AngelGualotuna
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;

        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();

        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var Registros = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, COntrasenia = txtContrasenia.Text };
                con.InsertAsync(Registros);
                DisplayAlert("Alerta", "Datos Ingresado","OK");
                txtNombre.Text = "";
                txtUsuario.Text = "";
                txtContrasenia.Text = "";
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "OK");

            }

        }
    }
}