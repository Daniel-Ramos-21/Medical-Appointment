using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Net.Http;
using Newtonsoft.Json;


namespace LogicaNegocio
{
    public class CitaBLL
    {
        private bool ESDiaFeriado(DateTime fecha)
        {
            //Construcion de la url dinamica segun el año de la cita.
            string url = $"https://date.nager.at/api/v3/PublicHolidays/{fecha.Year}/SV";

            //instaciamos un objeto de la clase httpclient
            using (HttpClient cliente = new HttpClient())
            {
                try
                {
                    //Llamada peticion Get a la API 
                    HttpResponseMessage respuesta = cliente.GetAsync(url).Result;

                    //Si la API responde con el 200 OK
                    if(respuesta.IsSuccessStatusCode)
                    {
                        //Leemos el JSON que nos devolvió el servidor
                        string jsonRespuesta = respuesta.Content.ReadAsStringAsync().Result;

                        //Traducimos el JSON a una lista de C# 
                        List<DiaFeriado>? diaFeriados = JsonConvert.DeserializeObject<List<DiaFeriado>>(jsonRespuesta);

                        //Verificamos si la fecha existe en la lista de feriados
                        bool coincide = diaFeriados.Any(f => f.Date.Day == fecha.Day && f.Date.Month == fecha.Month);

                        return coincide;
                    }
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
