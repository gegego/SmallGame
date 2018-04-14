import React, { Component } from 'react';
import PropTypes from 'prop-types';
import './Floodit.css';
import Model from './Model'

class Floodit extends Component {
  constructor() {
        super();
        this.state = { board: [], step:0, comstep:0, isWin:false };
    }

  componentWillMount(){
    fetch('http://45.77.125.230/GameAPI/floodit/', {
      method: 'GET',
      mode: 'cors',
    }).then((response) => {
      response.json().then((body) => {
          console.log(body);
          this.setState({board:body.board, comstep:body.step})
        });
    });
  }

  step = (e) =>{
    // console.log(e.target.value)
    var data = {
      "board":this.state.board,
      "step":e.target.value
    }
    // console.log(JSON.stringify(data));
    fetch('http://45.77.125.230/GameAPI/floodit/', {
      method: 'POST',
      body: JSON.stringify(data),
      headers: {
            'Content-Type': 'application/json'
        }
    }).then((response) => {
      response.json().then((body) => {
          if(body.isWin == true){
            console.log(body.isWin);
            this.setState({isWin:true});
          }
          this.setState({board:body.board, step:this.state.step+1});
        });
    });
  };

  toggleResult= () => {
    this.setState({
      isWin: !this.state.isWin
    });
    window.location.reload();
  }

  render() {
    var colors = ["red","blue","yellow"];
    var rows = this.state.board.map(function (item, i){
          var entry = item.map(function (element, j) {
              return (
                  <td className="boardcss" key={j} bgcolor={colors[element]}></td>
                  );
          });
          return (
              <tr key={i}>{entry}</tr>
           );
      });

    return (
      <div className="App">
        <div>
          <h1>Flood-it</h1>
        </div>
        <Model show={this.state.isWin} onClose={this.toggleResult} >
          <div className="lblscore">
            <a>Computer:{this.state.comstep}</a>
            <a>You:{this.state.step}</a>
          </div>
        </Model>
        <table align="center">
          <tbody>
              {rows}
          </tbody>
        </table>
        <div className="btnColor">
          <button value="0" style={{backgroundColor:colors[0]}} onClick={this.step} ></button>
          <button value="1" style={{backgroundColor:colors[1]}} onClick={this.step} ></button>
          <button value="2" style={{backgroundColor:colors[2]}} onClick={this.step} ></button>
        </div>
      </div>
    );
  }
}

export default Floodit;
