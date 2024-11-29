namespace eshop.Application
{
    public class Oyuncu
    {
        public void Giy(IKiyafet ust)
        {

        }
    }
    public interface IKiyafet
    {
        public void Giy();
    }
    public abstract class UstGiyim : IKiyafet
    {
        public void Giy()
        {
            throw new NotImplementedException();
        }
    }
    public class Kazak : UstGiyim { }
    public class KirmiziKazak : Kazak
    {

    }
}
