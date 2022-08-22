namespace Iscanner
{
    public interface IScanner
    {
        void Digitalizar();
        void Detener();
        bool Test();
        void Init();
        Utils.Utils.ImageResolution Resolucion { get; set; }
        string DirDestino { get; set; }
    }
}