using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Interfaces;
using FlooringOrderingSys.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.BLL
{
    public class TaxManager
    {
        private ITaxRepository _taxRepository;
        public TaxManager(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public LoadTaxesResponse LoadTaxes()
        {
            LoadTaxesResponse response = new LoadTaxesResponse();

            response.Taxes = _taxRepository.LoadTaxes();

            if (response.Taxes == null)
            {
                response.Success = false;
                response.Message = "No taxes found, Unable to get Tax information !!!!";
                return response;
            }

            response.Success = true;

            return response;
        }

        public Response AddTax(Tax tax)
        {
            Response response = new Response();
            response.Success = _taxRepository.AddTax(tax);
            if (response.Success)
            {
                response.Message = "Tax information Added Successfully !!!!";
            }
            else
            {
                response.Message = "Unable to Add Tax Information !!!!";
            }
            return response;
        }

        public TaxResponse GetTax(string stateAbbreviation)
        {
            TaxResponse response = new TaxResponse();

            response.Tax = _taxRepository.GetTax(stateAbbreviation);

            if (response.Tax == null)
            {
                response.Success = false;
                response.Message = "No Tax found !!!";
                return response;
            }

            response.Success = true;
            return response;
        }

        public Response EditTax(Tax newTax)
        {
            Response response = new Response();

            response.Success = _taxRepository.EditTax(newTax);

            if (response.Success)
            {
                response.Message = $"Tax({newTax.StateAbbreviation}) edited Successfully !!!!";
            }
            else
            {
                response.Message = $"Unable to Edit Tax({newTax.StateAbbreviation}) !!!!";
            }
            return response;
        }

        public Response RemoveTax(string stateAbbreviation)
        {
            Response response = new Response();

            response.Success = _taxRepository.RemoveTax(stateAbbreviation);

            if (response.Success)
            {
                response.Message = $"Tax({stateAbbreviation}) removed Successfully !!!!";
            }
            else
            {
                response.Message = $"Unable to remove Tax({stateAbbreviation}) !!!!";
            }

            return response;
        }
    }
}
