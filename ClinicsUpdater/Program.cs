using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Transactions;
using AutoMapper;
using DataJan = Hd_Jan_2013;
using DataJune = Hd_June_2011;
using Timer = System.Timers.Timer;

namespace ClinicsUpdater
{
    class Program
    {

        private static void InitMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DataJune.Categories, Categories>();
                cfg.CreateMap<DataJune.Areas, Areas>();
                cfg.CreateMap<DataJune.ClinicSubscriptions, ClinicSubscriptions>();
                cfg.CreateMap<DataJune.Clinics, Clinics>();
                cfg.CreateMap<DataJan.Categories, Categories>();
                cfg.CreateMap<DataJan.Areas, Areas>();
                cfg.CreateMap<DataJan.ClinicSubscriptions, ClinicSubscriptions>();
                cfg.CreateMap<DataJan.Clinics, Clinics>();

            });
        }

        private static void Main()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            InitMapper();
            UpdateClinics();
            UpdateCategories();
            UpdateAreas();
            UpdateClinicsForJan();
            UpdateCategoriesForJan();
            UpdateAreasForJan();
            stopWatch.Stop();
            Console.WriteLine($"Elapsed time: {stopWatch.ElapsedMilliseconds/1000/60}");
            Console.WriteLine("Success");
            Console.Read();
        }

        private static void UpdateAreas()
        {
            using (var ctx = new HealthDirContext())
            using (var juneCtx = new DataJune.HdJune2011Context())
            {
                var currentClinicsWithourAreas = ctx.Clinics.Include("Areas").Where(c => !c.Areas.Any()).ToList();
                var index = 0;
                foreach (var clinic in currentClinicsWithourAreas)
                {
                    var areas = new List<DataJune.Areas>();
                    try
                    {
                        areas = juneCtx.Clinics.Include("Areas")
                            .Single(c => c.Name.Equals(clinic.Name, StringComparison.OrdinalIgnoreCase))
                            .Areas.ToList();
                    }
                    catch
                    {
                        // ignored
                    }

                    if (!areas.Any()) continue;

                    foreach (var area in areas)
                    {
                        if (clinic.Areas.All(c => c.Name != area.Name))
                        {
                            var currentArea =
                                ctx.Areas.First(c => c.Name.Equals(area.Name, StringComparison.OrdinalIgnoreCase));
                            clinic.Areas.Add(currentArea);
                            Console.WriteLine($"{++index}.Added area");
                        }
                    }
                }
                try
                {
                    ctx.SaveChanges();
                    Console.WriteLine($"\t\t\tSaved changes for {index} items!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw ex;
                }
                Console.WriteLine("Success!");
            }

        }
        private static void UpdateAreasForJan()
        {
            using (var ctx = new HealthDirContext())
            using (var oldCtx = new DataJan.HdJan2013Context())
            {
                var currentClinicsWithourAreas = ctx.Clinics.Include("Areas").Where(c => !c.Areas.Any()).ToList();
                var index = 0;
                foreach (var clinic in currentClinicsWithourAreas)
                {
                    var areas = new List<DataJan.Areas>();
                    try
                    {
                        areas = oldCtx.Clinics.Include("Areas")
                            .Single(c => c.Name.Equals(clinic.Name, StringComparison.OrdinalIgnoreCase))
                            .Areas.ToList();
                    }
                    catch
                    {
                        // ignored
                    }

                    if (!areas.Any()) continue;

                    foreach (var area in areas)
                    {
                        if (clinic.Areas.All(c => c.Name != area.Name))
                        {
                            var currentArea =
                                ctx.Areas.First(c => c.Name.Equals(area.Name, StringComparison.OrdinalIgnoreCase));
                            clinic.Areas.Add(currentArea);
                            Console.WriteLine($"{++index}.Added area");
                        }
                    }
                }
                try
                {
                    ctx.SaveChanges();
                    Console.WriteLine($"\t\t\tSaved changes for {index} items!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw ex;
                }
                Console.WriteLine("Success!");
            }

        }

        private static void UpdateCategories()
        {
            using (var ctx = new HealthDirContext())
            using (var juneCtx = new DataJune.HdJune2011Context())
            {
                var currentClinicsWithoutCategories = ctx.Clinics.Include("Categories").Where(c => !c.Categories.Any())
                    .ToList();
                var index = 0;
                foreach (var currentClinic in currentClinicsWithoutCategories)
                {
                    List<DataJune.Categories> categories;
                    try
                    {
                        categories = juneCtx.Clinics.Include("Categories")
                            .Single(c => c.Name.Equals(currentClinic.Name, StringComparison.OrdinalIgnoreCase))
                            .Categories.ToList();
                    }
                    catch
                    {
                        continue;
                    }
                    if (index == 2000 || index == 5000 || index == 10000)
                    {
                        try
                        {
                            ctx.SaveChanges();
                            Console.WriteLine($"\t\t\tSaved changes for {index} items!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            throw ex;
                        }
                    }

                    if (!categories.Any()) continue;

                    foreach (var category in categories)
                    {

                        if (currentClinic.Categories.All(c => c.Name != category.Name))
                        {
                            var currentCategory =
                                ctx.Categories.First(c => c.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase));
                            currentClinic.Categories.Add(currentCategory);
                            Console.WriteLine($"{++index}.Added category");
                        }
                    }

                }
                try
                {
                    ctx.SaveChanges();
                    Console.WriteLine($"\t\t\tSaved changes for {index} items!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw ex;
                }
                Console.WriteLine("Success!");
            }
        }
        private static void UpdateCategoriesForJan()
        {
            using (var ctx = new HealthDirContext())
            using (var oldCtx = new DataJan.HdJan2013Context())
            {
                var currentClinicsWithoutCategories = ctx.Clinics.Include("Categories").Where(c => !c.Categories.Any())
                    .ToList();
                var index = 0;
                foreach (var currentClinic in currentClinicsWithoutCategories)
                {
                    List<DataJan.Categories> categories;
                    try
                    {
                        categories = oldCtx.Clinics.Include("Categories")
                            .Single(c => c.Name.Equals(currentClinic.Name, StringComparison.OrdinalIgnoreCase))
                            .Categories.ToList();
                    }
                    catch
                    {
                        continue;
                    }
                    if (index == 2000 || index == 5000 || index == 10000)
                    {
                        try
                        {
                            ctx.SaveChanges();
                            Console.WriteLine($"\t\t\tSaved changes for {index} items!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            throw ex;
                        }
                    }

                    if (!categories.Any()) continue;

                    foreach (var category in categories)
                    {

                        if (currentClinic.Categories.All(c => c.Name != category.Name))
                        {
                            var currentCategory =
                                ctx.Categories.First(c => c.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase));
                            currentClinic.Categories.Add(currentCategory);
                            Console.WriteLine($"{++index}.Added category");
                        }
                    }

                }
                try
                {
                    ctx.SaveChanges();
                    Console.WriteLine($"\t\t\tSaved changes for {index} items!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw ex;
                }
                Console.WriteLine("Success!");
            }
        }

        private static void ExportClinics()
        {
            using (var ctx = new DataJan.HdJan2013Context())
            {
                var clinics = ctx.Clinics.ToList();
                var strBuilder = new StringBuilder();
                var header = clinics[0].GetType().GetProperties();
                for (var index = 0; index < header.Length; index++)
                {
                    var propertyInfo = header[index];
                    strBuilder.Append(propertyInfo.Name);
                    if (index != header.Length - 1)
                    {
                        strBuilder.Append(",");
                    }
                }
                strBuilder.AppendLine();
                var i = 1;
                for (var index = 0; index < clinics.Count; index++)
                {
                    var clinic = clinics[index];
                    if (!string.IsNullOrWhiteSpace(clinic.AdmEmail))
                    {
                        AppendLinesToStrBuilder(clinic, strBuilder);
                        Console.WriteLine(i++);
                    }
                }
                Console.WriteLine("Done");
                File.WriteAllText($"{Directory.GetCurrentDirectory()}\\clinics-jan-2013.txt", strBuilder.ToString());
                Console.WriteLine("Success");
            }
        }

        private static void UpdateClinics()
        {
            var strBuilder = new StringBuilder();
            using (var ctx = new HealthDirContext())
            using (var juneCtx = new DataJune.HdJune2011Context())
            {
                var clinicsAdded = 0;
                var clinicsModified = 0;

                var juneClinics = juneCtx.Clinics.Where(c => !string.IsNullOrEmpty(c.AdmEmail)).ToList();
                var currentClinics = ctx.Clinics.ToList();
                foreach (var juneClinic in juneClinics)
                {

                    try
                    {
                        var existingClinics = currentClinics.Where(c => c.Name.Equals(juneClinic.Name, StringComparison.OrdinalIgnoreCase)).ToList();
                        if (existingClinics.Any())
                        {
                            foreach (var existingClinic in existingClinics)
                            {
                                if (string.IsNullOrWhiteSpace(existingClinic.AdmEmail) || existingClinic.AdmEmail.Equals("empty"))
                                {
                                    ValidateClinic(existingClinic);
                                    existingClinic.AdmEmail = juneClinic.AdmEmail;
                                    AppendLinesToStrBuilder(existingClinic, strBuilder);
                                    Console.WriteLine($"\t\t{clinicsModified}. Clinics Modified");
                                    clinicsModified++;

                                }
                            }
                        }
                        else
                        {
                            var mappedClinic = Mapper.Map<Clinics>(juneClinic);
                            ValidateClinic(mappedClinic);
                            ctx.Clinics.Add(mappedClinic);
                            AppendLinesToStrBuilder(mappedClinic, strBuilder);
                            Console.WriteLine($"{clinicsAdded}. Clinics Added");
                            clinicsAdded++;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                Console.WriteLine($"Modified: {clinicsModified}, \t\t Added: {clinicsAdded} ");
                File.WriteAllText($"{Directory.GetCurrentDirectory()}\\file-june.txt", strBuilder.ToString());
                Console.WriteLine("Success");
            }
        }
        private static void UpdateClinicsForJan()
        {
            var strBuilder = new StringBuilder();
            using (var ctx = new HealthDirContext())
            using (var oldCtx = new DataJan.HdJan2013Context())
            {
                var clinicsAdded = 0;
                var clinicsModified = 0;

                var oldClinics = oldCtx.Clinics.Where(c => !string.IsNullOrEmpty(c.AdmEmail)).ToList();
                var currentClinics = ctx.Clinics.ToList();
                foreach (var oldClinic in oldClinics)
                {

                    try
                    {
                        var existingClinics = currentClinics.Where(c => c.Name.Equals(oldClinic.Name, StringComparison.OrdinalIgnoreCase)).ToList();
                        if (existingClinics.Any())
                        {
                            foreach (var existingClinic in existingClinics)
                            {
                                if (string.IsNullOrWhiteSpace(existingClinic.AdmEmail) || existingClinic.AdmEmail.Equals("empty"))
                                {
                                    ValidateClinic(existingClinic);
                                    existingClinic.AdmEmail = oldClinic.AdmEmail;
                                    AppendLinesToStrBuilder(existingClinic, strBuilder);
                                    Console.WriteLine($"\t\t{clinicsModified}. Clinics Modified");
                                    clinicsModified++;

                                }
                            }
                        }
                        else
                        {
                            var mappedClinic = Mapper.Map<Clinics>(oldClinic);
                            ValidateClinic(mappedClinic);
                            ctx.Clinics.Add(mappedClinic);
                            AppendLinesToStrBuilder(mappedClinic, strBuilder);
                            Console.WriteLine($"{clinicsAdded}. Clinics Added");
                            clinicsAdded++;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                Console.WriteLine($"Modified: {clinicsModified}, \t\t Added: {clinicsAdded} ");
                File.WriteAllText($"{Directory.GetCurrentDirectory()}\\file-jan.txt", strBuilder.ToString());
                Console.WriteLine("Success");

            }
        }

        private static void AppendLinesToStrBuilder(object clinic, StringBuilder strBuilder)
        {
            var properties = clinic.GetType().GetProperties();
            for (var i = 0; i < properties.Length; i++)
            {
                strBuilder.Append($"{properties[i].GetValue(clinic, null)}");
                if (i != properties.Length - 1)
                {
                    strBuilder.Append(",");
                }
            }
            strBuilder.AppendLine();
        }

        private static void AppendNamesLines(string clinicName, StringBuilder strBuilder)
        {
            strBuilder.AppendLine(clinicName);
        }

        private static void ValidateClinic(Clinics clinic)
        {
            const string emp = "-";
            if (string.IsNullOrWhiteSpace(clinic.AdmEmail))
            {
                clinic.AdmEmail = emp;
            }
            if (string.IsNullOrWhiteSpace(clinic.InvoiceAddress))
            {
                clinic.InvoiceAddress = emp;
            }
            if (string.IsNullOrWhiteSpace(clinic.InvoiceCity))
            {
                clinic.InvoiceCity = emp;
            }
            if (string.IsNullOrWhiteSpace(clinic.InvoiceCountry))
            {
                clinic.InvoiceCountry = emp;
            }
            if (string.IsNullOrWhiteSpace(clinic.InvoiceZipcode))
            {
                clinic.InvoiceZipcode
                    = emp;
            }
            if (string.IsNullOrWhiteSpace(clinic.Address))
            {
                clinic.Address
                    = emp;
            }
            if (string.IsNullOrWhiteSpace(clinic.InvoiceName))
            {
                clinic.InvoiceName
                    = emp;
            }
            if (string.IsNullOrWhiteSpace(clinic.City))
            {
                clinic.City
                    = emp;
            }
            if (string.IsNullOrWhiteSpace(clinic.Zipcode))
            {
                clinic.Zipcode
                    = emp;
            }
            if (string.IsNullOrWhiteSpace(clinic.Name))
            {
                clinic.Name
                    = emp;
            }
        }
    }
}
