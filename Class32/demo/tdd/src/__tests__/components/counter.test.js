import React from 'react';
import { shallow, mount } from 'enzyme';
import renderer from 'react-test-renderer';

import Counter from '../../components/counter';

describe('<Counter />', () => {

  // This is a [Fact]
  it('initial count is zero', () => {
    // Arrange
    let app = shallow(<Counter />);

    // Assert
    expect(app.find('span.count').text()).toBe('0');
  });

  it('can increment counter', () => {
    // Arrange
    let app = shallow(<Counter />);

    // Act
    let button = app.find('button');
    button.simulate('click');

    // Assert
    expect(app.find('span.count').text()).toBe('1');
  });

  it('does not have a Header before click', () => {
    let app = shallow(<Counter />);

    expect(app.find('Header').exists()).toBe(false);
  })

  // mount is more expensive and renders child components
  it('does not have an h1 before click', () => {
    let app = mount(<Counter />);

    expect(app.find('h1').exists()).toBe(false);
  })

  it('has a Header after click', () => {
    let app = shallow(<Counter />);

    app.find('button').simulate('click');

    expect(app.find('Header').exists()).toBe(true);
  })

  // mount is more expensive and renders child components
  it('has an h1 after click', () => {
    let app = mount(<Counter />);

    app.find('button').simulate('click');

    expect(app.find('h1').exists()).toBe(true);
  })

  // Snapshot test!
  it('renders correctly', () => {
    let tree = renderer.create(<Counter />).toJSON();
    //console.log(tree);

    expect(tree).toMatchSnapshot();
  })
})
