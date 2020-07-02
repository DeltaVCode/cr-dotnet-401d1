import React from 'react';
import { RadialBarChart, PolarAngleAxis, RadialBar } from 'recharts';

export default function ToDoChart(props) {
  const circleSize = 300;
  const { list } = props;
  const completedCount = list.filter(item => item.completed).length;
  const data = [{ value: completedCount / list.length }];

  return (
    <RadialBarChart
      barSize={50}
      width={circleSize}
      height={circleSize}
      cx={circleSize / 2}
      cy={circleSize / 2}
      innerRadius={circleSize / 6}
      outerRadius={circleSize / 3}
      barSize={2}
      data={data}
      startAngle={90}
      endAngle={-270}
      >
      <PolarAngleAxis
        type="number"
        domain={[0, 1]}
        angleAxisId={0}
        tick={false}
        />
      <RadialBar
        background
        minPointSize={20}
        barSize={50}
        clockWise
        dataKey="value"
        cornerRadius={circleSize / 2}
        fill="#82ca9d"
        />
      <text
        x={circleSize / 2}
        y={circleSize / 2}
        textAnchor="middle"
        dominantBaseline="middle"
        className="progress-label"
        >
        {list.length - completedCount}
      </text>
    </RadialBarChart>
  )
}