//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Entity.Infrastructure.MappingViews;

[assembly: DbMappingViewCacheTypeAttribute(
    typeof(BLService.WCFEntities),
    typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySets75d2946ba0386992c4e57fb1b17f2bc8f1a3a91a571c89d1cf048887841b8f03))]

namespace Edm_EntityMappingGeneratedViews
{
    using System;
    using System.CodeDom.Compiler;
    using System.Data.Entity.Core.Metadata.Edm;

    /// <summary>
    /// Implements a mapping view cache.
    /// </summary>
    [GeneratedCode("Entity Framework 6 Power Tools", "0.9.2.0")]
    internal sealed class ViewsForBaseEntitySets75d2946ba0386992c4e57fb1b17f2bc8f1a3a91a571c89d1cf048887841b8f03 : DbMappingViewCache
    {
        /// <summary>
        /// Gets a hash value computed over the mapping closure.
        /// </summary>
        public override string MappingHashValue
        {
            get { return "75d2946ba0386992c4e57fb1b17f2bc8f1a3a91a571c89d1cf048887841b8f03"; }
        }

        /// <summary>
        /// Gets a view corresponding to the specified extent.
        /// </summary>
        /// <param name="extent">The extent.</param>
        /// <returns>The mapping view, or null if the extent is not associated with a mapping view.</returns>
        public override DbMappingView GetView(EntitySetBase extent)
        {
            if (extent == null)
            {
                throw new ArgumentNullException("extent");
            }

            var extentName = extent.EntityContainer.Name + "." + extent.Name;

            if (extentName == "WCFModelStoreContainer.TProduct")
            {
                return GetView0();
            }

            if (extentName == "WCFModelStoreContainer.TShop")
            {
                return GetView1();
            }

            if (extentName == "WCFEntities.TProduct")
            {
                return GetView2();
            }

            if (extentName == "WCFEntities.TShop")
            {
                return GetView3();
            }

            return null;
        }

        /// <summary>
        /// Gets the view for WCFModelStoreContainer.TProduct.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView0()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing TProduct
        [WCFModel.Store.TProduct](T1.TProduct_ID, T1.TProduct_Name, T1.TProduct_Price, T1.TProduct_Category, T1.TProduct_Date, T1.TProduct_Shop)
    FROM (
        SELECT 
            T.ID AS TProduct_ID, 
            T.Name AS TProduct_Name, 
            T.Price AS TProduct_Price, 
            T.Category AS TProduct_Category, 
            T.Date AS TProduct_Date, 
            T.Shop AS TProduct_Shop, 
            True AS _from0
        FROM WCFEntities.TProduct AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for WCFModelStoreContainer.TShop.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView1()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing TShop
        [WCFModel.Store.TShop](T1.TShop_Id, T1.TShop_Name)
    FROM (
        SELECT 
            T.Id AS TShop_Id, 
            T.Name AS TShop_Name, 
            True AS _from0
        FROM WCFEntities.TShop AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for WCFEntities.TProduct.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView2()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing TProduct
        [WCFModel.TProduct](T1.TProduct_ID, T1.TProduct_Name, T1.TProduct_Price, T1.TProduct_Category, T1.TProduct_Date, T1.TProduct_Shop)
    FROM (
        SELECT 
            T.ID AS TProduct_ID, 
            T.Name AS TProduct_Name, 
            T.Price AS TProduct_Price, 
            T.Category AS TProduct_Category, 
            T.Date AS TProduct_Date, 
            T.Shop AS TProduct_Shop, 
            True AS _from0
        FROM WCFModelStoreContainer.TProduct AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for WCFEntities.TShop.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView3()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing TShop
        [WCFModel.TShop](T1.TShop_Id, T1.TShop_Name)
    FROM (
        SELECT 
            T.Id AS TShop_Id, 
            T.Name AS TShop_Name, 
            True AS _from0
        FROM WCFModelStoreContainer.TShop AS T
    ) AS T1");
        }
    }
}