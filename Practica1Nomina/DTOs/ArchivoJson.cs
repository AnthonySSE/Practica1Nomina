namespace Practica1Nomina.DTOs
{
    public class ArchivoJson
    {
        private string id;
        public string Id { get { if (string.IsNullOrEmpty(id)) { return Guid.NewGuid().ToString(); } else return id; } set { id = value.ToString(); } }
    }
}
