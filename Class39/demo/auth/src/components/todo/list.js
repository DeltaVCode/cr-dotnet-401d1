import React from 'react';
import { Link } from 'react-router-dom';

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
          <button onClick={() => props.handleDelete(item.id)}>
              Delete
          </button>
        </li>
      ))}
    </ul>
  );
};

export default TodoList;
