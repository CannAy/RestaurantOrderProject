using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        //Tanımladığımız entitylere özgü işlemler için diğer tanımlanan interface'ler IGenericDal'dan kalıtım alacaklar!!

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id); // "T türünde" 
        List<T> GetListAll();
    }
}
