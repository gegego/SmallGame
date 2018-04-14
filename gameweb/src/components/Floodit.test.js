import React from 'react';
import ReactDOM from 'react-dom';
import Floodit from './Floodit';

it('renders without crashing', () => {
  const div = document.createElement('div');
  ReactDOM.render(<Floodit />, div);
  ReactDOM.unmountComponentAtNode(div);
});
