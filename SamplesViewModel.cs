﻿using System.Text;

namespace LINQSamples
{
    public class SamplesViewModel : ViewModelBase
    {
        #region GetAllQuery

        /// <summary>
        /// Put all products into a collection using LINQ
        /// </summary>
        public List<Product> GetAllQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = (from product in products select product).ToList();
            return list;
        }

        #endregion

        #region GetAllMethod

        /// <summary>
        /// Put all products into a collection using LINQ
        /// </summary>
        public List<Product> GetAllMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Method Syntax Here
            list = products
                .Select(product => product).ToList();

            return list;
        }

        #endregion

        #region GetSingleColumnQuery

        /// <summary>
        /// Select a single column
        /// </summary>
        public List<string> GetSingleColumnQuery()
        {
            List<Product> products = GetProducts();
            List<string> list = new();

            // Write Query Syntax Here
            list.AddRange(from product in products select product.Name);
            
            return list;
        }

        #endregion

        #region GetSingleColumnMethod

        /// <summary>
        /// Select a single column
        /// </summary>
        public List<string> GetSingleColumnMethod()
        {
            List<Product> products = GetProducts();
            List<string> list = new();

            // Write Method Syntax Here
            list.AddRange(products.Select(product => product.Name));

            return list;
        }

        #endregion

        #region GetSpecificColumnsQuery

        /// <summary>
        /// Select a few specific properties from products and create new Product objects
        /// </summary>
        public List<Product> GetSpecificColumnsQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = (from product in products
                    select new Product{
                        ProductID = product.ProductID,
                        Name = product.Name,
                        Size = product.Size
                    }).ToList();

            return list;
        }

        #endregion

        #region GetSpecificColumnsMethod

        /// <summary>
        /// Select a few specific properties from products and create new Product objects
        /// </summary>
        public List<Product> GetSpecificColumnsMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Method Syntax Here
            list = products.Select(product => new Product
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Size = product.Size
            }).ToList();

            return list;
        }

        #endregion

        #region AnonymousClassQuery

        /// <summary>
        /// Create an anonymous class from selected product properties
        /// </summary>
        public string AnonymousClassQuery()
        {
            List<Product> products = GetProducts();
            StringBuilder sb = new(2048);

            // Write Query Syntax Here


            // Loop through anonymous class
            //foreach (var prod in list)
            //{
            //  sb.AppendLine($"Product ID: {prod.Identifier}");
            //  sb.AppendLine($"   Product Name: {prod.ProductName}");
            //  sb.AppendLine($"   Product Size: {prod.ProductSize}");
            //}

            return sb.ToString();
        }

        #endregion

        #region AnonymousClassMethod

        /// <summary>
        /// Create an anonymous class from selected product properties
        /// </summary>
        public string AnonymousClassMethod()
        {
            List<Product> products = GetProducts();
            StringBuilder stringBuilder = new(2048);

            // Write Method Syntax Here
            var list = (from product in products
                select new
                {
                    Identifier = product.ProductID,
                    ProductName = product.Name,
                    ProductSize = product.Size
                }).ToList();

            // Loop through anonymous class
            foreach (var product in list)
            {
                stringBuilder.AppendLine($"Product ID: {product.Identifier}");
                stringBuilder.AppendLine($"   Product Name: {product.ProductName}");
                stringBuilder.AppendLine($"   Product Size: {product.ProductSize}");
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}