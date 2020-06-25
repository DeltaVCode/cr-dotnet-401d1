import React, { useEffect, useState } from 'react';
import { Route } from 'react-router-dom';
import useFetch from '../../hooks/fetch.js';
import TodoForm from './form.js';
import TodoList from './list.js';
import TodoItem from './item.js';

import './todo.scss';

// Should be in .env as REACT_APP_API_SERVER instead of hard coded
const todoAPI = 'https://deltav-todo.azurewebsites.net/api/v1/todos';

const ToDo = () => {
  const [todoList, setToDoList] = useState([]);

  // request() is a function from the hook that takes a url and options as a parameter object
  // response, error are data that the hook sets as state (letting us re-render here) when it's done fetchign data
  // isLoading is a flag set by the hook to let you change display if we're loading data
  // eslint-disable-next-line no-unused-vars
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

  const _toggleCompleted = id => {
    let item = todoList.filter(i => i.id === id)[0] || {};
    item.completed = !item.completed;
    const updateRequest = {
      url: `${todoAPI}/${id}`,
      options: {
        method: 'put',
        body: JSON.stringify(item)
      }
    }
    request(updateRequest);
  };

  const _getAll = React.useCallback(() => {
    const req = {
      url: todoAPI,
      options: {
        method: 'get'
      }
    }
    request(req);
  }, [request]);

  // The function to re-fetch data so the display is current
  // Called on intial load and afer every write operation
  // On mount ... get the list
  useEffect(() => {
    _getAll();
  }, [_getAll]);

  //  Set the full state if it's in the response or re-fetch anytime the response is updated
  useEffect(() => {
    // Anytime we get a list, update our sate
    if (response.length >= 0) {
      setToDoList(response);
    }
    // Otherwise, re-fetch
    else {
      _getAll();
    }
  }, [response, _getAll]);

  return (
    <>
      <header>
        <h2>
          There are {todoList.filter(item => !item.completed).length} Items To Complete
        </h2>
      </header>

      <section className="todo">

        <div>
          <TodoForm handleSubmit={_addItem} />
        </div>

        <div>
          <TodoList
            list={todoList}
            handleCompleted={_toggleCompleted}
            handleDelete={_deleteItem}
          />
        </div>
      </section>

      <Route
        path='/todo/:id'
        render={({ match }) => (
          <TodoItem item={todoList.find(item => item.id === Number(match.params.id))} />
        )} />
    </>
  );
};

export default ToDo;
