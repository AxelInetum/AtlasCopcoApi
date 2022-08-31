import axios from 'axios';
import Globals from '../Global';

class TruckService {

  base_url = Globals.BASE_URL;
  user_token = localStorage.getItem("token");

  getTruckList = async () => {
    debugger;
    return await axios
       .get(this.base_url+'GetListTruckFunction', { headers: { Authorization: `Bearer ${this.user_token}` } })
      .then(response => {
        return response.data;
      })
      .catch(function (error) {
           return null;
      });
  };

  insertTruck = async (truckSelected) => {
    debugger;
    return await axios
       .post(this.base_url+'CreateTruckFunction', truckSelected,{ headers: { Authorization: `Bearer ${this.user_token}` } })
      .then(response => {
        return response.data;
      })
      .catch(function (error) {
           return false;
      });
  };

  updateTruck = async (TruckSelected) => {
    return await axios
       .put(this.base_url+'UpdateTruckFunction', TruckSelected,{ headers: { Authorization: `Bearer ${this.user_token}` } })
      .then(response => {
        return response.data;
      })
      .catch(function (error) {
        return false;
      });
  };

  deleteTruck = async (id) => {
    return await axios
       .post(this.base_url+'DeleteTruckFunction' ,id ,{ headers: { Authorization: `Bearer ${this.user_token}` } })
      .then(response => {
        return response.data;
      })
      .catch(function (error) {
           return false;
      });
  };
}

export default TruckService;