using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.MagicStrings
{
    public static class Messages
    {
        public static string Added = "Added Successful!";
        public static string Deleted = "Deleted Successful!";
        public static string Updated = "Updated Successful!";

        public static string Listed = "Listed";

        public static string Error = "Error";

        public static string InvalidName = "Error! Invalid name.";

        #region ProductManager iş parçacıkları mesajları
        public static string MaximumProductQuantity = "The maximum quantity of products in this category has been reached!";
        public static string ProductNameAlreadyExists = "Product name already exists!";
        public static string CategoryLimitExceded = "New products cannot be added because the maximum number of categories has been reached.";
        #endregion

    }
}
