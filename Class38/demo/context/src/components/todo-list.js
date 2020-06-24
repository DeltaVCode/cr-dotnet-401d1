import React from 'react';
import useFetch from '../hooks/fetch';

export default function TodoList(props) {
  const [isLoading, data] = useFetch('https://deltav-todo.azurewebsites.net/api/v1/Todos');

  if (isLoading) {
    return (<h2>Loading...</h2>);
  }

  return (
    <ul>
      {data.map((item,index) => (
        <li key={index}>{item.title}</li>
      ))}
    </ul>
  )
}
