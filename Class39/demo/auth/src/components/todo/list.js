import React from 'react';
import { Link } from 'react-router-dom';

import Auth from '../auth';

const TodoList = (props) => {
  const list = props.list || [];

  return (
    <ul>
      { list.map(item => (
        <li
          className={`completed-${item.completed.toString()}`}
          key={item.id}
        >
          <span onClick={() => props.handleCompleted(item.id)}>
            {item.title}
          </span>
          <Link to={`/todo/${item.id}`}>
              Details
          </Link>
          <Auth permission='delete'>
            <button onClick={() => props.handleDelete(item.id)}>
                Delete
            </button>
          </Auth>
          <Auth not permission='delete'>
            You CAN'T Delete!
          </Auth>
        </li>
      ))}
    </ul>
  );
};

export default TodoList;
