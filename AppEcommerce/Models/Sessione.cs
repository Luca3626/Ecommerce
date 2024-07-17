using Newtonsoft.Json;

namespace AppEcommerce.Models
{
    public class Sessione<T>
    {
      
        private readonly string _chiave;

        public Sessione(string chiave)
        {
          
            _chiave = chiave;
        }

        public  T Deserializza(ISession session)
        {
           return JsonConvert.DeserializeObject<T>(session.GetString(_chiave));
        }
        public void Serializza(T c,ISession session)
        {

            session.SetString(_chiave, JsonConvert.SerializeObject(c));
           
        }
        public string GetJson(ISession session)
        {
            return session.GetString(_chiave);
        }
        public void Remove(ISession session)
        {
            session.Remove(_chiave);

        }


    }
}
