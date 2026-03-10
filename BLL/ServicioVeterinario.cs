using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioVeterinario : ICrudGenerico<Veterinario>
    {
        List<Veterinario> lista=null;
        public ServicioVeterinario()
        {
            lista = new List<Veterinario>();
        }

        public bool Actualizar(Veterinario veterinario)
        {
            throw new NotImplementedException();
        }

        public List<Veterinario> Consultar()
        {
            return lista;
        }

        public bool Eliminar(Veterinario veterinario)
        {
            if (lista.Count == 0 || lista == null)
            {
                return false;
            }

            if(lista.Any(v => v.Id == veterinario.Id))
            {
                lista.Remove(veterinario);
                return true;
            }

            else
            {
                return false;
            }
        }

        public string Guardar(Veterinario veterinario)
        {
            try
            {
                // validar
                if (lista.Any(v => v.Id == veterinario.Id))
                {
                    return $"El veterinario con ID {veterinario.Id} ya está registrado";
                }

                lista.Add(veterinario);
                return $"Se registro correctamente el veterinario {veterinario.Nombres} - ID: {veterinario.Id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
