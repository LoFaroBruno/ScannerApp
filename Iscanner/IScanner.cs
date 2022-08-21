namespace IScanner
{
    interface IScanner
    {
        void Digitalizar();
        void Detener();
        bool Test();
        Iscanner.Utils.Resolution Resolucion { get; set; }
        string DirDestino { get; set; }
    }
}
