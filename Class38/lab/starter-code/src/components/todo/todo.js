import React, { useEffect, useState } from 'react';
import useFetch from '../../hooks/fetch.js';
import { When } from '../if';
import TodoForm from './form.js';
import TodoList from './list.js';
import TodoItem from './item.js';

import './todo.scss';

// Should be in .env as REACT_APP_API_SERVER instead of hard coded
const todoAPI = 'https://localhost:44331/api/v1/todos';

const ToDo = () => {

  const [todoList, setToDoList] = useState([]);
  const [showDetails, setShowDetails] = useState(false);
  const [showItem, setShowItem] = useState({});

  // request() is a function from the hook that takes a url and options as a parameter object
  // response, error are data that the hook sets as state (letting us re-render here) when it's done fetchign data
  // isLoading is a flag set by the hook to let you change display if we're loading data
  const { request, response, error, isLoading } = useFetch();

  // Notice how all of the event handlers set a request object and call request() with it?
  // the hook has a useEffect() that's tied to changes in the request object, so as these
  // change that bit of state in the hook, api calls happen

  const _addItem = (item) => {
    const addRequest = {
      url: todoAPI,
      options: {
        method: 'post',
        body: JSON.stringify(item)
      }
    }
    request(addRequest);
  };

  const _deleteItem = (id) => {
    const deleteRequest = {
      url: `${todoAPI}/${id}`,
      options: {
        method: 'delete'
      }
    }
    request(deleteRequest);
  };

  const _toggleComplete = id => {
    let item = todoList.filter(i => i._id === id)[0] || {};
    item.complete = !item.complete;
    const updateRequest = {
      url: `${todoAPI}/${id}`,
      options: {
        method: 'put',
        body: JSON.stringify(item)
      }
    }
    request(updateRequest);
  };

  const _toggleDetails = id => {
    setShowDetails(!showDetails);
    let item = todoList.filter(item => item._id === id)[0];
    setShowItem(item);
  };

  const _getAll = () => {
    const req = {
      url: todoAPI,
      options: {
        method: 'get'
      }
    }
    request(req);
  }

  // The function to re-fetch data so the display is current
  // Called on intial load and afer every write operation
  // On mount ... get the list
  useEffect(() => {
    _getAll();
  }, []);

  //  Set the full state if it's in the response or re-fetch anytime the response is updated
  useEffect(() => {
    // Anytime we get a list, update our sate
    if (response.count >= 0) {
      setToDoList(response.results);
    }
    // Otherwise, re-fetch
    else {
      _getAll();
    }
  }, [response]);

  return (
    <>
      <header>
        <h2>
          There are {todoList.filter(item => !item.complete).length} Items To Complete
        </h2>
      </header>

      <section className="todo">

        <div>
          <TodoForm handleSubmit={_addItem} />
        </div>

        <div>
          <TodoList
            list={todoList}
            handleComplete={_toggleComplete}
            handleDelete={_deleteItem}
            handleDetails={_toggleDetails}
          />
        </div>
      </section>

      <When condition={showDetails}>
        <TodoItem handleDetails={_toggleDetails} item={showItem} />
      </When>
    </>
  );
};

export default ToDo;
