import React from 'react';
import useAuth from '../../contexts/auth';

export default function AuthButton(props) {
  const { permissions } = useAuth();
  const { permission, disabledTitle, ...rest } = props;

  if (permissions.includes(permission)) {
    return <button {...rest} />;
  }
  
  return <button {...rest} disabled
    title={disabledTitle || `Permission '${permission}' is required.`}
     />;
}
