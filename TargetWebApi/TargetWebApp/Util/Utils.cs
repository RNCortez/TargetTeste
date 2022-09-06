using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TargetWebApp.Util
{
    public class Utils
    {
        public CultureInfo cultureInfo = new CultureInfo("pt-BR");
        public int ValueIntForm(FormCollection form, string key)
        {
            int valorInt = -1;
            try
            {
                valorInt = Convert.ToInt32(form[key].ToString().Trim());

            }
            catch (Exception) { }

            return valorInt;
        }

        public string ValueStringForm(FormCollection form, string key)
        {
            string valorString = string.Empty;
            try
            {
                valorString = form[key].ToString().Trim();
            }
            catch (Exception) { }

            return valorString;
        }
        public decimal ValueDecimalForm(FormCollection form, string key)
        {
            decimal valorDecimal = 0;
            try
            {
                valorDecimal = ToDecimal(form[key].ToString().Trim());
            }
            catch (Exception) { }

            return valorDecimal;
        }

        public DateTime ValueDateTimeForm(FormCollection form, string key)
        {
            DateTime data = DateTime.MinValue;
            try
            {
                DateTime.TryParse(form[key], out data);
            }
            catch (Exception) { }

            return data;
        }
       
        public static CultureInfo GetCultura(string culture)
        {
            return new CultureInfo(culture);
        }

        public static CultureInfo GetCulturaSystem()
        {
            return new CultureInfo("pt-BR");
        }

        public decimal ToDecimal(string valor)
        {
            decimal valorDecimal = Convert.ToDecimal(valor, new CultureInfo("pt-BR"));

            return valorDecimal;
        }

        public static string DecimalToString(decimal valorDecimal)
        {
            string valor = string.Empty;

            try
            {
                valor = valorDecimal.ToString("#,##0.00", new CultureInfo("pt-BR"));
            }
            catch { }

            return valor;
        }
    }
}