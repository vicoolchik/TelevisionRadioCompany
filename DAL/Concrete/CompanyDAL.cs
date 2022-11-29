﻿using AutoMapper;
using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Concrete
{
    public class CompanyDAL : ICompany
    {
        private readonly IMapper _mapper;
        public CompanyDAL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CompanyDTO CreateCompany(CompanyDTO company)
        {
            using (var entites = new TelevisionRadioCompanyContext())
            {
                var companyInDB = _mapper.Map<Company>(company);
                entites.Companies.Add(companyInDB);
                entites.SaveChanges();
                return _mapper.Map<CompanyDTO>(companyInDB);
            }
        }

        public List<CompanyDTO> GetAllCompanies()
        {
            using (var entities = new TelevisionRadioCompanyContext())
            {
                var companies = entities.Companies.ToList();
                return _mapper.Map<List<CompanyDTO>>(companies);
            }
        }


        public CompanyDTO DeleteCompanyByID(int id)
        {
            using (var entites = new TelevisionRadioCompanyContext())
            {
                var companyInDB = entites.Companies.SingleOrDefault(x => x.Id == id);
                if (companyInDB != null)
                {
                    entites.Companies.Remove(companyInDB);
                    entites.SaveChanges();
                    return _mapper.Map<CompanyDTO>(companyInDB);
                }
                return null;
            }
        }

        public CompanyDTO EditCompanyByID(CompanyDTO company, int id)
        {
            using (var entites = new TelevisionRadioCompanyContext())
            {
                var companyInDB = _mapper.Map<Company>(company);
                companyInDB = entites.Companies.SingleOrDefault(x => x.Id == id);
                if (companyInDB != null)
                {
                    companyInDB.Name = company.Name;
                    companyInDB.Phone = company.Phone;
                    companyInDB.AddressId = company.AddressId;
                    entites.SaveChanges();
                    return _mapper.Map<CompanyDTO>(companyInDB);
                }
                return null;
            }
        }

        public CompanyDTO DeleteCompany(CompanyDTO company)
        {
            using (var entites = new TelevisionRadioCompanyContext())
            {
                var companyInDB = _mapper.Map<Company>(company);
                companyInDB = entites.Companies.SingleOrDefault(x => x.Id == company.Id);
                if (companyInDB != null)
                {
                    entites.Companies.Remove(companyInDB);
                    entites.SaveChanges();
                    return _mapper.Map<CompanyDTO>(companyInDB);
                }
                return null;
            }
        }

        public CompanyDTO EditCompany(CompanyDTO company)
        {
            using (var entites = new TelevisionRadioCompanyContext())
            {
                var companyInDB = _mapper.Map<Company>(company);
                companyInDB = entites.Companies.SingleOrDefault(x => x.Id == company.Id);
                if (companyInDB != null)
                {
                    companyInDB.Name = company.Name;
                    companyInDB.Phone = company.Phone;
                    companyInDB.AddressId = company.AddressId;
                    entites.SaveChanges();
                    return _mapper.Map<CompanyDTO>(companyInDB);
                }
                return null;
            }
        }

    }
}

