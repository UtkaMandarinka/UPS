//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KUR.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductTable()
        {
            this.OrderTable = new HashSet<OrderTable>();
        }
    
        public int id_product { get; set; }
        public Nullable<int> id_type_product { get; set; }
        public Nullable<int> id_warehouse { get; set; }
        public Nullable<int> id_supplier { get; set; }
        public string name_product { get; set; }
        public Nullable<int> price_product { get; set; }
        public Nullable<int> weight_product { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderTable> OrderTable { get; set; }
        public virtual SupplierTable SupplierTable { get; set; }
        public virtual TypeProductTable TypeProductTable { get; set; }
        public virtual WarehouseTable WarehouseTable { get; set; }
    }
}
