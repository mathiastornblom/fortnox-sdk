﻿using System.Collections.Generic;

namespace FortnoxAPILibrary.Connectors
{
    public interface ISupplierConnector : IEntityConnector<Sort.By.Supplier>
    {
        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string City { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string OrganisationNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string Phone { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string SupplierNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string ZipCode { get; set; }

        /// <summary>
        /// Get a supplier based on suppliernumber
        /// </summary>
        /// <param name="supplierNumber">The suppliernumber to find</param>
        /// <returns>The resulting supplier</returns>
        Supplier Get(string supplierNumber);

        /// <summary>
        /// Updates a supplier
        /// </summary>
        /// <param name="supplier">The supplier entity to update</param>
        /// <returns>The updated supplier</returns>
        Supplier Update(Supplier supplier);

        /// <summary>
        /// Create a new supplier
        /// </summary>
        /// <param name="supplier">The supplier entity to create</param>
        /// <returns>The created supplier</returns>
        Supplier Create(Supplier supplier);

        /// <summary>
        /// Deletes at supplier
        /// </summary>
        /// <param name="supplierNumber">The suppliernumber to delete</param>
        /// <returns></returns>
        void Delete(string supplierNumber);

        /// <summary>
        /// Gets a list of suppliers
        /// </summary>
        /// <returns>A list of suppliers</returns>
        Suppliers Find();
    }

    /// <remarks/>
	public class SupplierConnector : EntityConnector<Supplier, Suppliers, Sort.By.Supplier>, ISupplierConnector
    {

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string City { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string Email { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string Name { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string OrganisationNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string Phone { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string SupplierNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string ZipCode { get; set; }

		/// <remarks/>
		public SupplierConnector()
		{
			base.Resource = "suppliers";
		}

		/// <summary>
		/// Get a supplier based on suppliernumber
		/// </summary>
		/// <param name="supplierNumber">The suppliernumber to find</param>
		/// <returns>The resulting supplier</returns>
		public Supplier Get(string supplierNumber)
		{
			return BaseGet(supplierNumber);
		}

		/// <summary>
		/// Updates a supplier
		/// </summary>
		/// <param name="supplier">The supplier entity to update</param>
		/// <returns>The updated supplier</returns>
		public Supplier Update(Supplier supplier)
		{
			return base.BaseUpdate(supplier, supplier.SupplierNumber);
		}

		/// <summary>
		/// Create a new supplier
		/// </summary>
		/// <param name="supplier">The supplier entity to create</param>
		/// <returns>The created supplier</returns>
		public Supplier Create(Supplier supplier)
		{
			return base.BaseCreate(supplier);
		}

		/// <summary>
		/// Deletes at supplier
		/// </summary>
		/// <param name="supplierNumber">The suppliernumber to delete</param>
		/// <returns></returns>
		public void Delete(string supplierNumber)
		{
			base.BaseDelete(supplierNumber);
		}

		/// <summary>
		/// Gets a list of suppliers
		/// </summary>
		/// <returns>A list of suppliers</returns>
		public Suppliers Find()
		{
			return base.BaseFind();
		}
	}
}
