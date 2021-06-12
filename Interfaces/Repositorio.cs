using System.Collections.Generic;
namespace MenuSeries.Interfaces
{
    public interface Repositorio<Serie>
    {
       
        List<Serie> Lista();
        Serie RetornaPorId(int id);        
        void Insere(Serie objeto);        
        void Exclui(int id);        
        void Atualiza(int id, Serie objeto);
        int ProximoId();    
    }
}