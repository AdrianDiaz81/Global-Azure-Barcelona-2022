import * as React from 'react';
import { avengerAPI } from '../../api';

export const useAvengerCollection = () => {
    const [avengerCollection, setAvengerCollection] = React.useState([]);
    const loadAvengers = () => {
        avengerAPI.getAvengersAsync()
          .then(json => setAvengerCollection(json));
    };
      return {avengerCollection, loadAvengers, setAvengerCollection};
};