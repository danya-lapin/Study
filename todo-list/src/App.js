import React from "react";
import materialize from "materialize-css"

function App() {
  return (
    <div className="App">
        <ul className="collection with-header">
            <li className="collection-header"><h4>ToDo List</h4></li>
            <li className="collection-item">Finish this</li>
            <a className="btn-floating btn-large waves-effect waves-light red"><i className="material-icons">add</i></a>
        </ul>
    </div>
  );
}

export default App;
