using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace Biblioteka_system
{
    class Klasa_glowna
    {



        public void ShowWypozyczenia(string polecenie, SqlConnection conn1, string nazwa_tabeli, ListView listavieww)
        {
            
            string polecenieDS = polecenie;
            string nazwa_Tab = nazwa_tabeli;
            SqlConnection conn = conn1;
            ListView listaWypozyczen = listavieww;

            SqlDataAdapter sqladapaterklient = new SqlDataAdapter(polecenieDS, conn);
            DataTable tabela = new DataTable(nazwa_Tab);
            sqladapaterklient.Fill(tabela);
            listaWypozyczen.ItemsSource = tabela.DefaultView;
            sqladapaterklient.Update(tabela);
        }

        public void DataSeting(string polecenie, string nazwa,SqlConnection conn)
        {
            string polcenie2 = polecenie;
            string nazwa_tabeli = nazwa;
            SqlConnection conn1 = conn;
             DataSet ds = new DataSet();

             SqlDataAdapter sqlada = new SqlDataAdapter(polcenie2, conn1);
            sqlada.Fill(ds, nazwa_tabeli);

        }
    }
}
