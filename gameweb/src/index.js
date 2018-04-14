import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import Floodit from './components/Floodit';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(<Floodit />, document.getElementById('root'));
registerServiceWorker();
