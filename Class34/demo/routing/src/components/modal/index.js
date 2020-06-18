import React from 'react';
import './modal.scss';

const Modal = props => {
  const { title, onClose, children } = props;

  return (
    <div className="overlay">
      <div className="modal">
        <div className="header">
          <span className="title">{title}</span>
          <button onClick={onClose}>&times;</button>
        </div>
        <div className="content">
          {children}
        </div>
      </div>
    </div>
  );
}

export default Modal;
