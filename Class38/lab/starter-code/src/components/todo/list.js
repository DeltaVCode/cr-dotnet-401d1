import React from 'react';

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
          <button onClick={() => props.handleDetails(item.id)}>
              Details
          </button>
          <button onClick={() => props.handleDelete(item.id)}>
              Delete
          </button>
        </li>
      ))}
    </ul>
  );
};

export default TodoList;
