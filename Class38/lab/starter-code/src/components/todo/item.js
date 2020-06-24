import React from 'react';
import Modal from '../modal';

const Item = (props) => {

  const { item } = props;
  if (!item) {
    return (
      <Modal title="To Do Item" close={props.handleDetails}>
        <h2>Item Not Found</h2>
      </Modal>
    );
  }

  const stars = [1,2,3,4,5].map(x => x <= item.difficulty ? '★' : '☆').join('');

  return (
    <Modal title="To Do Item" close={props.handleDetails}>
      <div className="todo-details">
        <header>
          <span>Assigned To: {item.assignedTo}</span>
          <span>Difficulty: {stars}</span>
        </header>
        <div className="item">
          {item.title}
        </div>
      </div>
    </Modal>
  );
};

export default Item;
