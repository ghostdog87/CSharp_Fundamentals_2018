using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Car
    {
        //<carModel> <carSpeed>
        public string CarModel { get; set; }
        public int CarSpeed { get; set; }

        public Car(string carModel, int carSpeed)
        {
            CarModel = carModel;
            CarSpeed = carSpeed;
        }
    }
}
