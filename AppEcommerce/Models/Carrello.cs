namespace AppEcommerce.Models
{
    public class Carrello
    {
        public readonly List<ProdottoSelezionato>? ProdottiSel=new List<ProdottoSelezionato>();

      public void AddProdotto(ProdottoSelezionato p)
        {
            ProdottoSelezionato prodotto= FindProduct(p.IdProdotto);
            if (prodotto==null)
                ProdottiSel!.Add(p);
            else
            {
                prodotto.Qs += 1;
            }
        }
        public void ClearCarrello()
        {
            ProdottiSel?.Clear();   
        }
        public int NumProdotti()
        {
            return ProdottiSel!.Count();
        }
      
        public ProdottoSelezionato FindProduct(long id)
        {

            return ProdottiSel!.Find(s => s.IdProdotto == id);

        }
        public void ClearProduct(long id)
        {
            ProdottiSel.Remove(ProdottiSel.Find(p=>p.IdProdotto==id));  

        }
        public string? GetTotal() {
            return $"{ProdottiSel.Sum(p => p.Qs * p.Prezzo):F2}";
        }
        public void EditProductQs(long id,int qs)
        {

            ProdottiSel!.Find(s => s.IdProdotto == id).Qs = qs;

        }
    }
}
