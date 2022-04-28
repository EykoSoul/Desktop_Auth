//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelekomNevaSvyz.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Заявки
    {
        public int ID_Заявки { get; set; }
        public string Номер_заявки { get; set; }
        public System.DateTime Дата_создания { get; set; }
        public int ЛС { get; set; }
        public string Услуга { get; set; }
        public int Вид_услуги { get; set; }
        public string Тип_услуги { get; set; }
        public string Статус { get; set; }
        public int ID_Оборудования { get; set; }
        public string Проблемы { get; set; }
        public Nullable<System.DateTime> Дата_закрытия { get; set; }
        public string Тип_проблемы { get; set; }
        public int ID_Сотрудника { get; set; }
        public int ID_района { get; set; }
        public int ID_Абонента { get; set; }
    
        public virtual Абонент Абонент { get; set; }
        public virtual ВидУслуг ВидУслуг { get; set; }
        public virtual Оборудование Оборудование { get; set; }
        public virtual Районы Районы { get; set; }
        public virtual ТехПерсонал ТехПерсонал { get; set; }
    }
}
