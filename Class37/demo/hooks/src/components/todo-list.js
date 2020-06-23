import React from 'react';
import useFetch from '../hooks/fetch';

export default function TodoList(props) {
  const [isLoading, data] = useFetch('https://localhost:44331/api/v1/Todos');

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
