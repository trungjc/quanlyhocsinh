namespace ETO
{
    using System;

    public class IRoles
    {
        private int rolesId;
        private string rolesModules;
        private string rolesName;

        public int RolesID
        {
            get
            {
                return this.rolesId;
            }
            set
            {
                this.rolesId = value;
            }
        }

        public string RolesModules
        {
            get
            {
                return this.rolesModules;
            }
            set
            {
                this.rolesModules = value;
            }
        }

        public string RolesName
        {
            get
            {
                return this.rolesName;
            }
            set
            {
                this.rolesName = value;
            }
        }
    }
}

