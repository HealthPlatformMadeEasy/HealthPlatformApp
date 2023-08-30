import { useState } from "react";

const tabs = [
  { label: "Tab 1", content: <div>Tab 1 Content</div> },
  { label: "Tab 2", content: <div>Tab 2 Content</div> },
  { label: "Tab 3", content: <div>Tab 3 Content</div> },
];

export const Tabs = () => {
  const [activeTab, setActiveTab] = useState(0);

  const handleTabClick = (index: number) => {
    setActiveTab(index);
  };

  return (
    <div className="tabs grid w-1/3 rounded-xl border-2 border-pine_green-600 p-2">
      <div className="tab-list flex gap-4">
        {tabs.map((tab, index) => (
          <div
            key={index}
            onClick={() => handleTabClick(index)}
            className={`tab ${
              index === activeTab
                ? "active rounded-xl border border-pine_green-600 bg-pine_green-800 p-2"
                : "p-2"
            }`}
          >
            {tab.label}
          </div>
        ))}
      </div>
      <div className="tab-content">{tabs[activeTab].content}</div>
    </div>
  );
};
