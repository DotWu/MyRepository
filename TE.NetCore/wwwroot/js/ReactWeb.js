
function UserGreeting(props) {
    return (<h1>欢迎回来！</h1>);
}
function GuestGreeting(props) {
    return (
        <h1>请先注册！</h1>);
}
function Greeting(props) {
    const isLoggedIn = props.isLoggedIn;
    if (isLoggedIn) {
        return (
            <UserGreeting />);
    }
    return (
        <GuestGreeting />);
}
ReactDOM.render(
    <Greeting isLoggedIn={true} />, document.getElementById("isGreet"));

class Toggle extends React.Component {
    constructor(props) {
        super(props);

        this.state = { isToggleOn: true };

        //这边绑定是必要的，这样‘this’才能在回调函数中使用
        this.handleClick = this.handleClick.bind(this);
    }
    handleClick() {
        this.setState(prevState => ({
            isToggleOn: !prevState.isToggleOn
        }));
    }
    render() {
        return (
            <button onClick={this.handleClick}>
                {this.state.isToggleOn ? 'ON' : 'OFF'}
            </button>
        );
    }
}
ReactDOM.render(
    <Toggle />,
    document.getElementById('Onclick')
);

class WebSite extends React.Component {
    constructor() {
        super();
        this.state = {
            name: "自学",
            site: "https.//www.runoob.com"
        }
    }

    render() {
        return (
            <div>
                <Name name={this.state.name} />
                <Link site={this.state.site} />
            </div>);
    }
}

class Name extends React.Component {
    render() {
        return (
            <h1>{this.props.name}</h1>
        );
    }
}

class Link extends React.Component {
    render() {
        return (
            <a href={this.props.site}>{this.props.site}</a>
        );
    }
}

ReactDOM.render(
    <WebSite />, document.getElementById('stateProps'));


function FormattedDate(props) {
    return (
        <h2>现在是 {props.date.toLocaleTimeString()}.</h2>);
}

class Clock extends React.Component {
    constructor(props) {
        super(props);
        this.state = { date: new Date() };
    }
    componentDidMount() {  //生命周期钩子
        this.timerID = setInterval(() => this.tick(), 1000);   //设置定时器
    }
    componentWillUnmount() {  //生命周期钩子
        clearInterval(this.timerID);   ///卸载定时器
    }
    tick() {
        this.setState({
            date: new Date()
        });
    }
    render() {
        return (
            <div>
                <h1>Hello,world!</h1>
                <FormattedDate date={this.state.date} />
            </div>
        );
    }
}

function Apps() {
    return (
        <div>
            <Clock />
            <Clock />
            <Clock />
        </div>
    );
}
ReactDOM.render(
    <Apps />, document.getElementById('showDate'));


///复合组件
function Name(props) {
    return (
        <h1>网站名称：{props.name}</h1>);
}
function Url(props) {
    return (
        <h2>网站地址：{props.url}</h2>);
}
function Nickname(props) {
    return (
        <h3>网站小名：{props.nickname}</h3>);
}
function App(props) {
    return (
        <div>
            <Name name="喜发金融" />
            <Url url="www.konghey.com" />
            <Nickname nickname="喜发" />
        </div>
    );
};
ReactDOM.render(
    <App />,
    document.getElementById("assembly")
);


function HelloMessage(props) {
    return (
        <h1>Hello {props.name}!</h1>);  //换行需要加().
};

const element =
    <HelloMessage name="Runoob" />;
ReactDOM.render(
    element,
    document.getElementById("runoob")
);



var myStyle = {
    fontSize: 24,
    color: '#FF0000'
};
ReactDOM.render(
    <div>
        <h1>{1 + 1}</h1>
        {/*注释...*/}
        <h1>{1 == 1 ? 'true' : 'false'}</h1>
        <h3 style={myStyle}>欢迎学习React</h3>
        <p data-myattribute="somevalue">这是一个不错的javascript库</p>
    </div>,
    document.getElementById("example")
);
