using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace KostaSoft.Model
{

    public class OrgBuilder
    {
        private TreeItem root;

        public TreeItem Root
        {
            get { return root; }
            private set { root = value; }
        }

        public void Sotring(List<IOrgItem> input)
        {
            List<IOrgItem> excluded = new List<IOrgItem>();
            int i = -1;
            while (input.Count != excluded.Count)
            {
                i++;
                if (i == input.Count)
                    i = 0;

                IOrgItem org = input[i];

                if (excluded.Contains(org))
                    continue;

                if (String.IsNullOrEmpty(org.ParentDepartmentID))
                {
                    Root = new TreeItem(org);
                    excluded.Add(org);
                    continue;
                }

                TreeItem item = SearchItem(Root, org);
                if (item != null)
                {
                    if (!item.ContainsOrgItem(org))
                    {
                        TreeItem newItem = new TreeItem(org, item);
                        item.Children.Add(newItem);
                    }

                    excluded.Add(org);
                }
            }
        }

        private TreeItem SearchItem(TreeItem item, IOrgItem org)
        {
            if (item == null)
                return null;

            if (item.Value.ItemId.Equals(org.ParentDepartmentID))
                return item;

            foreach (var child in item.Children)
            {
                TreeItem result = SearchItem(child, org);
                if (result != null)
                    return result;
            }

            return null;
        }

    }

    public class TreeItem
    {
        public TreeItem(IOrgItem value, TreeItem parent = null)
        {
            Value = value;
            Parent = parent;
            Children = new List<TreeItem>();
        }
        public TreeItem Parent { get; set; }
        public IOrgItem Value { get; set; }
        public List<TreeItem> Children { get; set; }

        public string Name
        {
            get { return Value.Name; }
        }

        public bool ContainsOrgItem(IOrgItem org)
        {
            if (Children != null)
                foreach (var child in Children)
                    if (child.Value.Equals(org))
                        return true;

            return false;

        }
    }
}
