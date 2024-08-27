namespace EShopper.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings  //Interfaceler üzerinden işlemleri yürütürüz solidi ezmemek için classlar yerine interfaceler üzerinden yürütücez
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
