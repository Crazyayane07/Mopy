using MOP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOP.View
{
    public class InventoryView : MonoBehaviour2
    {
        public Trash[] teammates;
        public InventorySlot[] slots;

        private void Start()
        {
            SetUp();
        }

        public void SetUp()
        {
            SetUpSlots();
        }

        private void SetUpSlots()
        {
            for (int i = 0; i < teammates.Length && i < slots.Length; i++)
                slots[i].SetUp(teammates[i]);
        }
    }
}
