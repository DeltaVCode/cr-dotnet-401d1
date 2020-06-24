import React from 'react';

const TodoList = (props) => {

  const list = props.list || [];

  return (
    <ul>
      { list.map(item => (
        <li
          className={`complete-${item.complete.toString()}`}
          key={item._id}
        >
          <span onClick={() => props.handleComplete(item._id)}>
            {item.text}
          </span>
          <button onClick={() => props.handleDetails(item._id)}>
              Details
          </button>
          <button onClick={() => props.handleDelete(item._id)}>
              Delete
          </button>
        </li>
      ))}
    </ul>
  );
};

export default TodoList;
