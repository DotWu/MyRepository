var web = new Vue({
    el: '#web',
    data: {
        message: 'Hello Vue!'
    }
})
web.message = 'I am going to learn Vue!';
var web2 = new Vue({
    el: "#web-2",
    data: {
        message: '页面加载于' + new Date().toLocaleString()
    }
})
web2.message = '新消息';
var web3 = new Vue({
    el: '#web-3',
    data: {
        seen: true
    }
})
web3.seen = false;
var web4 = new Vue({
    el: '#web-4',
    data: {
        todos: [
            { text: '学习 javaScript' },
            { text: '学习 Vue' },
            { text: '整个项目' }
        ]
    }
})
web4.todos.push({ text: '新项目' });
var web5 = new Vue({
    el: '#web-5',
    data: {
        message: 'Hello Vue.js!'
    },
    methods: {
        reverseMessage: function () {
            this.message = this.message.split('').reverse().join('')
        }
    }
})

var web6 = new Vue({
    el: '#web-6',
    data: {
        message: 'Hello Vue!'
    }
})
//定义名为todo-item的新组建
Vue.component('todo-item', {
    props: ['todo'],
    template: '<li>{{todo.text}}</li>'
})
var web7 = new Vue({
    el: '#web-7',
    data: {
        groceryList: [
            { id: 0, text: 'C' },
            { id: 1, text: 'C++' },
            { id: 2, text: 'C#' }
        ]
    }
})
//我们的一个对象
var data = { a: 1 };
//该对象被加入到一个Vue实例中
var vm = new Vue({
    el:'#example',
    data:data
})
vm.$data === data; ///=>true
vm.$el === document.getElementById('exmaple'); //=>true

//$watch是一个实例方法
vm.$watch('a', function (newValue, oldValue) {
    //这个回调将在'vm.a'改变后调用

})

//获得这个实例上的属性
//还回源数据中对应的字段
vm.a = data.a;  //=>true

//设置属性也会影响到原始数据
vm.a = 2;
data.a;  //=>2
//反之亦然
data.a = 3;
vm.a;  //=>3

data.b = 'hi';
data: {
    newTodoText: ''
    visitCount: 0
    hideCompletedTodos: false
    todos: []
    error: null
}
var obj = {
    foo:'bar'
}
Object.freeze(obj)
new Vue({
    data: {
        a:1
    },
    created: function () {
        //this vm实例
        //console.log('a is:'+this.a)
    },
    el: '#app',
    data: obj
})  //=>"a is :1 "

vm = new Vue({
    el: '#example',
    data: {
        message: 'Hello'
    },
    computed: {
        //计算属性的getter
        reversedMessage: function () {
            //this 指向 vm实例
            return this.message.split('').reverse().join('')
        }
    }
})

var vmde = new Vue({
    el: '#demo',
    data: {
        firstName: 'Foo',
        lastName:'bar'
    },
    computed: {
        //FullName: function () {
        //    return this.firstName + ' ' + this.lastName
        //}
        get: function () {
            return this.firstName + ' ' + this.lastName
        },
        set: function (newValue) {
            var names = newValue.split(' ')
            this.firstName = names[0]
            this.lastName = names[names.length - 1]
        }
    }
})
vmde.fullName = 'John Doe';
var watchExampleVM = new Vue({
    el: '#watch-example',
    data: {
        question: '',
        answer:'I cannot give you an answer until you ask a question!'
    },
    watch: {
        //如果question 发生改变，这个函数就会运行
        question: function (newQuestion, oldQuestion) {
            this.answer = 'Waiting for you to stop typing...'
            this.debouncedGetAnswer()
        }
    },
    created: function () {
        //_.debounce是一个通过Lodash限制操作频率的函数
        //在这个例子中，我们希望限制访问yesno .wtf/api的频率
        //Ajax请求直到用户输入完毕才会发出。想要了解更多关于
        //_.debounce 函数（及其近亲_.throttle)的知识，
        //请参考：https://lodash.com/docs#debounce
        this.debouncedGetAnswer=_.debounce(this.getAnswer,500)
    },
    methods: {
        getAnswer: function () {
            if (this.question.indexOf('?') === -1) {
                this.answer = 'Questions usually contain a question mark .';
                return;
            }
            this.answer = 'Thinking...';
            var vm = this;
            axios.get('https://yesno.wtf/api').then(function (response) {
                vm.answer = _.capitalize(response.data.answer)
            }).catch(function (error) {
                vm.answer = 'Error! Could not reach the API.' + error;
            })
        }
    }
})


var appRegister = new Vue({
    el: "appRegister",
    components: {
        'component-a':""
    }
})

var example1 = new Vue({
    el: '#example-1',
    data: {
        items: [
            { message: 'Foo' },
            { message: 'Bar' }
        ]
    }
})

var example2 = new Vue({
    el: '#example-2',
    data: {
        parentMessage: 'Parent',
        items: [
            { message: 'Foo' },
            { message: 'Bar' },
            { message: 'Dot' }
        ]
    }
})

var vfor= new Vue({
    el: "#v-for-object",
    data: {
        object: {
            firstName: 'John',
            lastName: 'Doe',
            age: 30
        }
    }
})

var dot1 = new Vue({
    el: "#Dot1",
    data: {
        numbers:[1,2,3,4,5]
    },
    evenNumbers: function () {
        return this.numbers.filter(function (number) {
            return number%2===0
        })
    }
})
var dot2 = new Vue({
    el: "#Dot2",
    data: {
        numbers: [1, 2, 3, 4, 5]
    },
    methods: {
        even: function (numbers) {
            return this.numbers.filter(function (number) {
                return number % 2 === 0
            })
        }
    }
})

Vue.component('todo-item', {
    template: '<li>{{title}}<button v-on:click="$emit(\'remove\')">Remove</button></li>',
    props:['title']
})
new Vue({
    el: '#todo-list-example',
    data: {
        newTodoText: '',
        todos: [
            {
                id: 1,
                title:'Do the dishes',
            }, {
                id: 2,
                title:'Take out the trash',
            }, {
                id: 3,
                title:'Mow the lawn'
            }
        ],
        nextTodoId:4
    },
    methods: {
        addNewTodo: function () {
            this.todos.push({
                id: this.nextTodoId++,
                title:this.newTodoText
            })
            this.newTodoText=''
        }
    }
})

var example3 = new Vue({
    el: '#example-3',
    data: {
        counter:0
    }
})

var example4 = new Vue({
    el: '#example-4',
    data: {
        name:'Vue.js'
    },
    methods: {
        greet: function (event) {
            alert('Hello' + this.name + '!')
            if (event) {
                alert(event.target.tagName)
            }
        }
    }
})
example4.greet();  //=>'Hello Vue.js'

new Vue({
    el: '#example-5',
    methods: {
        say: function (message) {
            alert(message)
        }
    },
    methods: {
        warn: function (message, event) {
            if (event) event.preventDefault()
            alert(message)
        }
    }
})

Vue.component('component-a', { /* ... */ })
Vue.component('component-b', { /* ... */ })
Vue.component('component-c', { /* ... */ })




