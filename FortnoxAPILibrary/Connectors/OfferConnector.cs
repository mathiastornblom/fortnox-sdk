﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace FortnoxAPILibrary.Connectors
{
    public interface IOfferConnector : IFinancialYearBasedEntityConnector<Offer, Offers, Sort.By.Offer>
    {
        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string FromDate { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string ToDate { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string CostCenter { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string CustomerName { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string CustomerNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string DocumentNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string OurReference { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string Project { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string YourReference { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string Label { get; set; }

        /// <remarks/>
        bool Sent { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        bool NotCompleted { get; set; }

        /// <remarks/>
        Filter.Offer FilterBy { get; set; }

        /// <summary>
        /// Gets an offer
        /// </summary>
        /// <param name="documentNumber">The document number of the offer to find</param>
        /// <returns>An offer</returns>
        Offer Get(string documentNumber);

        /// <summary>
        /// Updates an offer
        /// </summary>
        /// <param name="offer">The offer to update</param>
        /// <returns>The updated offer</returns>
        Offer Update(Offer offer);

        /// <summary>
        /// Create a new offer
        /// </summary>
        /// <param name="offer">The offer to create</param>
        /// <returns>The created offer</returns>
        Offer Create(Offer offer);

        /// <summary>
        /// Gets a list of offers
        /// </summary>
        /// <returns>A list of offers</returns>
        Offers Find();

        /// <summary>
        /// Cancel an offer
        /// </summary>
        /// <param name="documentNumber">The document number of the offer to cancel</param>
        /// <returns>The cancelled offer</returns>
        Offer Cancel(string documentNumber);

        /// <summary>
        /// Emails an offer
        /// </summary>
        /// <param name="documentNumber">The document number of the offer to be emailed</param>
        void Email(string documentNumber);

        /// <summary>
        /// Prints an offer
        /// </summary>
        /// <param name="documentNumber">The document number of the offer to print</param>
        /// <param name="localPath">Where to save the printed offer. If omitted the offer will be set to printed (i.e Sent = true) and no pdf is returned. </param>
        void Print(string documentNumber, string localPath = "");

        /// <summary>
        /// Marks the document as externally printed
        /// </summary>
        /// <param name="documentNumber"></param>
        void ExternalPrint(string documentNumber);

        /// <summary>
        /// Creates an order from the specified offer
        /// </summary>
        /// <param name="documentNumber">The document number of the offer to create order from</param>
        /// <returns></returns>
        Offer CreateOrder(string documentNumber);
    }

    /// <remarks/>
	public class OfferConnector : FinancialYearBasedEntityConnector<Offer, Offers, Sort.By.Offer>, IOfferConnector
    {
		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string FromDate { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string ToDate { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string CostCenter { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string CustomerName { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		public string CustomerNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string DocumentNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string OurReference { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string Project { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string YourReference { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
        public string Label { get; set; }


		private bool sentSet = false;
		private bool sent;
		/// <remarks/>
		[FilterProperty]
		public bool Sent
		{
			get
			{
				return sent;
			}
			set
			{
				sent = value;
				sentSet = true;
			}
		}

		private bool notCompletedSet = false;
		private bool notcompleted;
		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		public bool NotCompleted
		{
			get
			{
				return notcompleted;
			}
			set
			{
				notcompleted = value;
				notCompletedSet = true;
			}
		}

		private bool filterBySet = false;
		private Filter.Offer filterBy;
		/// <remarks/>
		[FilterProperty("filter")]
		public Filter.Offer FilterBy
		{
			get { return filterBy; }
			set
			{
				filterBy = value;
				filterBySet = true;
			}
		}

		/// <remarks/>
		public enum DiscountType
		{
			/// <remarks/>
			AMOUNT,
			/// <remarks/>
			PERCENT
		}

		/// <remarks/>
		public OfferConnector()
		{
			base.Resource = "offers";
		}

		/// <summary>
		/// Gets an offer
		/// </summary>
		/// <param name="documentNumber">The document number of the offer to find</param>
		/// <returns>An offer</returns>
		public Offer Get(string documentNumber)
		{
			return base.BaseGet(documentNumber.ToString());
		}

		/// <summary>
		/// Updates an offer
		/// </summary>
		/// <param name="offer">The offer to update</param>
		/// <returns>The updated offer</returns>
		public Offer Update(Offer offer)
		{
			return base.BaseUpdate(offer, offer.DocumentNumber.ToString());
		}

		/// <summary>
		/// Create a new offer
		/// </summary>
		/// <param name="offer">The offer to create</param>
		/// <returns>The created offer</returns>
		public Offer Create(Offer offer)
		{
			return base.BaseCreate(offer);
		}

		/// <summary>
		/// Gets a list of offers
		/// </summary>
		/// <returns>A list of offers</returns>
		public Offers Find()
		{
			return base.BaseFind();
		}

		/// <summary>
		/// Cancel an offer
		/// </summary>
		/// <param name="documentNumber">The document number of the offer to cancel</param>
		/// <returns>The cancelled offer</returns>
		public Offer Cancel(string documentNumber)
		{
			return base.DoAction(documentNumber, "cancel");
		}

		/// <summary>
		/// Emails an offer
		/// </summary>
		/// <param name="documentNumber">The document number of the offer to be emailed</param>
		public void Email(string documentNumber)
		{
			base.DoAction(documentNumber, "email");
		}

		/// <summary>
		/// Prints an offer
		/// </summary>
		/// <param name="documentNumber">The document number of the offer to print</param>
		/// <param name="localPath">Where to save the printed offer. If omitted the offer will be set to printed (i.e Sent = true) and no pdf is returned. </param>
		public void Print(string documentNumber, string localPath = "")
		{
			if (string.IsNullOrEmpty(localPath))
			{
				base.DoAction(documentNumber, "externalprint");
			}
			else
			{
				base.LocalPath = localPath;
				base.DoAction(documentNumber, "print");
			}
		}

        /// <summary>
        /// Marks the document as externally printed
        /// </summary>
        /// <param name="documentNumber"></param>
        public void ExternalPrint(string documentNumber)
        {
            base.DoAction(documentNumber, "externalprint");
        }

		/// <summary>
		/// Creates an order from the specified offer
		/// </summary>
		/// <param name="documentNumber">The document number of the offer to create order from</param>
		/// <returns></returns>
		public Offer CreateOrder(string documentNumber)
		{
			return base.DoAction(documentNumber, "createorder");
		}
	}
}
