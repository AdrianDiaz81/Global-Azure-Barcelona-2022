import * as React from 'react';
import IAvengers from '../model/iavengers';
import { avengerAPI } from '../api';
import { useAvengerCollection } from './custom/useAvengersCollection';

export const LoadListComponent = () => {
    const [avengerCollection, setAvengerCollection] = React.useState([]);
    const fetchAvenger= async () => {
        const apiCall= await     avengerAPI.getAvengersAsync();
        setAvengerCollection(apiCall);
      }
     const [filter,setFilter]= React.useState('');
     React.useEffect(() => {
         fetchAvenger();
     },[avengerCollection.length]);


        let i:number=0;
        const avengerFilter:IAvengers[]=  avengerCollection.filter(x=>x.name.toString().search(filter)===0);
return (

<div className="container">
<div className="row">
<div className="col-lg-12 my-3">
            <div className="pull-right">
                <div className="btn-group">
                {/* <NavLink className='btn btn-info' exact={true} to={'/anyadir'} >
        Añadir
                </NavLink>                 */}
                </div>
            </div>
        </div>
    </div>
    <div className="col-md-6 col-md-offset-3">
                <div className="well well-sm">
                    <div className="form-group">
                        <label className="col-md-3 control-label" htmlFor="name">Buscar</label>
                        <div className="col-md-9">
                            <input id="name" name="name" type="text" placeholder="Name Avenger" onChange={(value)=>{setFilter(value.target.value)}} className="form-control"/>
                        </div>
                    </div>
                </div>
    </div>
    <div id="products" className="row view-group">
        {
            avengerFilter.map((item:IAvengers)=>{
                i=i+1;
                const editar: string = '/editar/'+item.id;
                return (
                    <div className="item col-xs-4 col-lg-4" key={item.id}>
                    <div className="thumbnail card">
                        <div className="img-event">
                            <img className="group list-group-image img-fluid" src={item.image} alt="" />
                        </div>
                        <div className="caption card-body">
                            <h4 className="group card-title inner list-group-item-heading">
                                {item.name}</h4>
                            <p className="group inner list-group-item-text">
                                {item.description}
                            </p>
                            <div className="row">
                                <div className="col-xs-12 col-md-6">
                                {/* <NavLink exact={true} to={editar} className="btn btn-success" >
                                    Editar
                                </NavLink>                                     */}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>                );
            })
        }
   </div>
</div>)
    }